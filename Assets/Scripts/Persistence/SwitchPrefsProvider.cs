#if UNITY_SWITCH && !UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Switch;
using nn;
using nn.fs;
using nn.account;
using File = nn.fs.File;

namespace Fiftytwo
{
    public class SwitchPrefsProvider : IPrefsProvider
    {
        private const string MountName = "save";
        private const string FileName = "kensho-preferences.dat";

        private readonly Uid _userId;
        private readonly string _filePath;
        private FileHandle _fileHandle;

        private readonly Dictionary<string, object> _data;

        public SwitchPrefsProvider ()
        {
            Account.Initialize();

            UserHandle userHandle = new UserHandle();

            Account.OpenPreselectedUser( ref userHandle );
            Account.GetUserId( ref _userId, userHandle );

            Result result = SaveData.Mount( MountName, _userId );
            result.abortUnlessSuccess();

            _filePath = string.Format( "{0}:/{1}", MountName, FileName );
            _fileHandle = new FileHandle();

            _data = InitializeFromFile();
        }

        private Dictionary<string, object> InitializeFromFile ()
        {
            EntryType entryType = 0;
            Result result = FileSystem.GetEntryType( ref entryType, _filePath );
            if( FileSystem.ResultPathNotFound.Includes( result ) )
                return new Dictionary<string, object>();
            result.abortUnlessSuccess();

            result = File.Open( ref _fileHandle, _filePath, OpenFileMode.Read );
            result.abortUnlessSuccess();

            long fileSize = 0;
            result = File.GetSize( ref fileSize, _fileHandle );
            result.abortUnlessSuccess();

            byte[] data = new byte[fileSize];
            result = File.Read( _fileHandle, 0, data, fileSize );
            result.abortUnlessSuccess();

            File.Close( _fileHandle );

            if( fileSize == 0 )
                return new Dictionary<string, object>();

            using( var stream = new MemoryStream( data ) )
            {
                return ( Dictionary<string, object> )new BinaryFormatter().Deserialize( stream );
            }
        }

        public void Flush ()
        {
            byte[] buffer;
            using( var stream = new MemoryStream() )
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize( stream, _data );
                stream.Close();
                buffer = stream.GetBuffer();
            }

            // Nintendo Switch Guideline 0080
            Notification.EnterExitRequestHandlingSection();

            Result result = File.Delete( _filePath );
            if( !FileSystem.ResultPathNotFound.Includes( result ) )
                result.abortUnlessSuccess();

            result = File.Create( _filePath, buffer.LongLength );
            result.abortUnlessSuccess();

            result = File.Open( ref _fileHandle, _filePath, OpenFileMode.Write );
            result.abortUnlessSuccess();

            result = File.Write( _fileHandle, 0, buffer, buffer.LongLength, WriteOption.Flush );
            result.abortUnlessSuccess();

            File.Close( _fileHandle );
            result = SaveData.Commit( MountName );
            result.abortUnlessSuccess();

            // Nintendo Switch Guideline 0080
            Notification.LeaveExitRequestHandlingSection();
        }

        public bool GetBool( string key, bool defaultValue = false )
        {
            object result;
            if( !_data.TryGetValue( key, out result ) )
                return defaultValue;
            return ( bool )result;
        }

        public void SetBool( string key, bool value )
        {
            _data[key] = value;
        }

        public int GetInt( string key, int defaultValue = 0 )
        {
            object result;
            if( !_data.TryGetValue( key, out result ) )
                return defaultValue;
            return ( int )result;
        }

        public void SetInt( string key, int value )
        {
            _data[key] = value;
        }

        public float GetFloat( string key, float defaultValue = 0.0f )
        {
            object result;
            if( !_data.TryGetValue( key, out result ) )
                return defaultValue;
            return ( float )result;
        }

        public void SetFloat( string key, float value )
        {
            _data[key] = value;
        }

        public string GetString( string key, string defaultValue = "" )
        {
            object result;
            if( !_data.TryGetValue( key, out result ) )
                return defaultValue;
            return ( string )result;
        }

        public void SetString( string key, string value )
        {
            _data[key] = value;
        }

        public bool HasKey ( string key )
        {
            return _data.ContainsKey( key );
        }

        public void DeleteKey ( string key )
        {
            _data.Remove( key );
        }

        public void DeleteAll()
        {
            _data.Clear();
        }
    }
}

#endif
