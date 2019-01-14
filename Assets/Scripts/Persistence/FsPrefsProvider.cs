//#define ENABLE_PLAYER_PREFS_HOOKS
//#define ENABLE_FS_PREFS_PROVIDER

#if ENABLE_FS_PREFS_PROVIDER

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Fiftytwo
{
    public class FsPrefsProvider : DictionaryPrefsProvider
    {
        private readonly Stream _stream;
        private readonly StreamWriter _writer;
        private readonly StringBuilder _sb = new StringBuilder();

        public FsPrefsProvider ()
        {
#if !UNITY_EDITOR
            if( !Directory.Exists( Application.persistentDataPath ) )
                Directory.CreateDirectory( Application.persistentDataPath );

            var prefsFilePath = Application.persistentDataPath + "/preferences.ini";

            if( string.IsNullOrEmpty( prefsFilePath ) )
            {
                Dbg.Error( "Can't get preferences.json path" );
                _data = new Dictionary<string, object>();
                return;
            }

            try
            {
                if( !File.Exists( prefsFilePath ) )
                {
                    _data = new Dictionary<string, object>();
                }
                else
                {
                    using( var sr = File.OpenText( prefsFilePath ) )
                    {
                        _data = GetDataFromText( sr );
                    }
                }
            }
            catch( Exception ex )
            {
                Dbg.Error( "Can't open preferences.json for read: {0}", ex );
                _data = new Dictionary<string, object>();
            }

            try
            {
                _stream = File.Open( prefsFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read );
                _writer = new StreamWriter( _stream );

                Dbg.Log( "FS Prefs Initialized at path \"{0}\"", prefsFilePath );
            }
            catch( Exception ex )
            {
                Dbg.Error( "Can't open preferences.json for write: {0}", ex );
            }
#endif
        }

        public override void Flush ()
        {
            if( _stream == null )
            {
                Dbg.Error( "Can't flush, stream is null" );
                return;
            }

            string str;
            _stream.Seek( 0, SeekOrigin.Begin );
            foreach( var pair in _data )
            {
                _writer.Write( pair.Key );
                _writer.Write( '=' );
                if( pair.Value is int || pair.Value is bool )
                {
                    str = pair.Value.ToString();
                }
                else if( pair.Value is float )
                {
                    str = ( ( float )pair.Value).ToString( CultureInfo.InvariantCulture );
                    if( str.IndexOf( '.' ) < 0 )
                        str += ".0";
                }
                else
                {
                    str = EscapeString( pair.Value.ToString() );
                }
                _writer.WriteLine( str );
            }

            _writer.Flush();
            _stream.SetLength( _stream.Position );
        }

        private Dictionary<string, object> GetDataFromText ( StreamReader sr )
        {
            var data = new Dictionary<string, object>();

            for( var line = sr.ReadLine(); !sr.EndOfStream; line = sr.ReadLine() )
            {
                if( string.IsNullOrEmpty( line ) )
                    continue;

                var equalIndex = line.IndexOf( '=' );
                if( equalIndex < 0 )
                    continue;
                var key = line.Substring( 0, equalIndex ).Trim();
                var val = line.Substring( equalIndex + 1 ).Trim();

                if( string.IsNullOrEmpty( val ) )
                {
                    data[key] = "";
                    continue;
                }

                if( val[0] == '"' )
                {
                    data[key] = UnescapeString( val, 1, val.Length - 2 );
                    continue;
                }

                int intVal;
                if( int.TryParse( val, out intVal ) )
                {
                    data[key] = intVal;
                    continue;
                }

                float floatVal;
                if( float.TryParse( val, NumberStyles.Number, CultureInfo.InvariantCulture, out floatVal ) )
                {
                    data[key] = floatVal;
                    continue;
                }

                bool boolVal;
                if( bool.TryParse( val, out boolVal ) )
                {
                    data[key] = boolVal;
                    continue;
                }

                data[key] = UnescapeString( val, 0, val.Length );
            }

            return data;
        }

        private string EscapeString ( string str )
        {
            _sb.Length = 0;
            _sb.Append( '\"' );
            for( int i = 0; i < str.Length; ++i )
            {
                var ch = str[i];
                if( ch == '\\' )
                    _sb.Append( "\\\\" );
                else if( ch == '\"' )
                    _sb.Append( "\\\"" );
                else if( ch == '\n' )
                    _sb.Append( "\\n" );
                else if( ch == '\r' )
                    _sb.Append( "\\r" );
                else
                    _sb.Append( ch );
            }
            _sb.Append( '\"' );
            return _sb.ToString();
        }

        private string UnescapeString ( string str, int startIndex, int length )
        {
            _sb.Length = 0;
            length += startIndex;
            for( int i = startIndex; i < length; ++i )
            {
                var ch = str[i];
                if( ch == '\\' )
                {
                    ch = str[++i];
                    if( ch == 'n' )
                        _sb.Append( '\n' );
                    else if( ch == 'r' )
                        _sb.Append( '\r' );
                    else
                        _sb.Append( ch );
                }
                else
                {
                    _sb.Append( ch );
                }
            }
            return _sb.ToString();
        }

        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void SetPlayerPrefsHooks ()
        {
#if ENABLE_PLAYER_PREFS_HOOKS && !UNITY_EDITOR
            var me = ( FsPrefsProvider )Persistence.Player;
            PlayerPrefsHooks.TrySetInt = me.TrySetInt;
            PlayerPrefsHooks.TrySetFloat = me.TrySetFloat;
            PlayerPrefsHooks.TrySetString = me.TrySetString;
            PlayerPrefsHooks.GetInt = me.GetInt;
            PlayerPrefsHooks.GetFloat = me.GetFloat;
            PlayerPrefsHooks.GetString = me.GetString;
            PlayerPrefsHooks.HasKey = me.HasKey;
            PlayerPrefsHooks.DeleteKey = me.DeleteKey;
            PlayerPrefsHooks.DeleteAll = me.DeleteAll;
            PlayerPrefsHooks.Initialize();
#else
            Debug.Log( "PlayerPrefsHooks is disabled" );
#endif
        }

#if ENABLE_PLAYER_PREFS_HOOKS
        private bool TrySetInt ( string key, int value )
        {
            SetInt( key, value );
            return true;
        }

        private bool TrySetFloat ( string key, float value )
        {
            SetFloat( key, value );
            return true;
        }

        private bool TrySetString ( string key, string value )
        {
            SetString( key, value );
            return true;
        }
#endif
    }
}

#endif
