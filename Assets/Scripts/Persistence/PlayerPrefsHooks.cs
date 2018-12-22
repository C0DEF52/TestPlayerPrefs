#if true //ENABLE_IL2CPP

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.InteropServices;
//using UnityEditor;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Fiftytwo
{
    public static class PlayerPrefsHooks
    {
        private delegate bool TrySetIntDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, int value);
        private delegate bool TrySetFloatDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, float value);
        private delegate bool TrySetSetStringDelegate(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string value);
        private delegate int GetIntDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, int defaultValue);
        private delegate float GetFloatDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, float defaultValue);
        [return: MarshalAs( UnmanagedType.LPWStr )]
        private delegate  string GetStringDelegate(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string defaultValue);
        private delegate bool HasKeyDelegate([MarshalAs( UnmanagedType.LPWStr )] string key);
        private delegate void DeleteKeyDelegate([MarshalAs( UnmanagedType.LPWStr )] string key);
        private delegate void DeleteAllDelegate();
        private delegate void SaveDelegate();

        [StructLayout(LayoutKind.Sequential)]
        private struct Callbacks
        {
            public TrySetIntDelegate TrySetInt;
            public TrySetFloatDelegate TrySetFloat;
            public TrySetSetStringDelegate TrySetSetString;
            public GetIntDelegate GetInt;
            public GetFloatDelegate GetFloat;
            public GetStringDelegate GetString;
            public HasKeyDelegate HasKey;
            public DeleteKeyDelegate DeleteKey;
            public DeleteAllDelegate DeleteAll;
            public SaveDelegate Save;
        }

        private static readonly Callbacks _callbacks = new Callbacks
        {
            TrySetInt = OnTrySetInt,
            TrySetFloat = OnTrySetFloat,
            TrySetSetString = OnTrySetSetString,
            GetInt = OnGetInt,
            GetFloat = OnGetFloat,
            GetString = OnGetString,
            HasKey = OnHasKey,
            DeleteKey = OnDeleteKey,
            DeleteAll = OnDeleteAll,
            Save = OnSave,
        };

        private static readonly Dictionary<string, object> _storage = new Dictionary<string, object>();

        public static void InstallHooks ()
        {
            Fiftytwo_PlayerPrefs_InstallHooks( _callbacks );
        }

        [DllImport("__Internal")]
        private static extern void Fiftytwo_PlayerPrefs_InstallHooks( Callbacks callbacks );

        [AOT.MonoPInvokeCallback( typeof( TrySetIntDelegate ) )]
        private static bool OnTrySetInt(string key, int value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetFloatDelegate ) )]
        private static bool OnTrySetFloat(string key, float value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetSetStringDelegate ) )]
        private static bool OnTrySetSetString(string key, string value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( GetIntDelegate ) )]
        private static int OnGetInt(string key, int defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is int )
                defaultValue = ( int )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetFloatDelegate ) )]
        private static float OnGetFloat(string key, float defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is float )
                defaultValue = ( float )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetStringDelegate ) )]
        private static string OnGetString(string key, string defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is string )
                defaultValue = ( string )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( HasKeyDelegate ) )]
        private static bool OnHasKey(string key)
        {
            var hasKey = _storage.ContainsKey( key );
            Dbg.Log( "HasKey[{0}]? {1}", key, hasKey );
            return hasKey;
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteKeyDelegate ) )]
        private static void OnDeleteKey(string key)
        {
            _storage.Remove( key );
            Dbg.Log( "Delete[{0}]", key );
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteAllDelegate ) )]
        private static void OnDeleteAll()
        {
            _storage.Clear();
            Dbg.Log( "DeleteAll" );
        }

        [AOT.MonoPInvokeCallback( typeof( SaveDelegate ) )]
        private static void OnSave()
        {
            Dbg.Log( "Save" );
        }
    }
}

#endif
