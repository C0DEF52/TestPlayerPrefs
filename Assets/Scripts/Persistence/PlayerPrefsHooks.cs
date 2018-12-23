#define ENABLE_IL2CPP
#define ENABLE_PLAYER_PREFS_HOOKS

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
        public delegate bool TrySetIntDelegate(string key, int value);
        public delegate bool TrySetFloatDelegate(string key, float value);
        public delegate bool TrySetSetStringDelegate( string key, string value);
        public delegate int GetIntDelegate(string key, int defaultValue);
        public delegate float GetFloatDelegate(string key, float defaultValue);
        public delegate  string GetStringDelegate(string key, string defaultValue);
        public delegate bool HasKeyDelegate(string key);
        public delegate void DeleteKeyDelegate(string key);
        public delegate void DeleteAllDelegate();
        public delegate void SaveDelegate();


        public static TrySetIntDelegate TrySetInt;
        public static TrySetFloatDelegate TrySetFloat;
        public static TrySetSetStringDelegate TrySetSetString;
        public static GetIntDelegate GetInt;
        public static GetFloatDelegate GetFloat;
        public static GetStringDelegate GetString;
        public static HasKeyDelegate HasKey;
        public static DeleteKeyDelegate DeleteKey;
        public static DeleteAllDelegate DeleteAll;
        public static SaveDelegate Save;


        public static void SetCallbacks ()
        {
#if ENABLE_IL2CPP && ENABLE_PLAYER_PREFS_HOOKS
            Fiftytwo_PlayerPrefsHooks_SetCallbacks( _callbacks );
#else
    #if !ENABLE_IL2CPP
            Debug.LogAssertion( "IL2CPP is disabled" );
    #endif
    #if !ENABLE_PLAYER_PREFS_HOOKS
            Debug.LogAssertion( "PlayerPrefsHooks is disabled" );
    #endif
#endif
        }


#if ENABLE_IL2CPP && ENABLE_PLAYER_PREFS_HOOKS

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


        [DllImport("__Internal")]
        private static extern void Fiftytwo_PlayerPrefsHooks_SetCallbacks( Callbacks callbacks );


        [AOT.MonoPInvokeCallback( typeof( TrySetIntDelegate ) )]
        private static bool OnTrySetInt([MarshalAs( UnmanagedType.LPWStr )] string key, int value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetFloatDelegate ) )]
        private static bool OnTrySetFloat([MarshalAs( UnmanagedType.LPWStr )] string key, float value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetSetStringDelegate ) )]
        private static bool OnTrySetSetString(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string value)
        {
            _storage[key] = value;
            Dbg.Log( "_storage[{0}] = {1}", key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( GetIntDelegate ) )]
        private static int OnGetInt([MarshalAs( UnmanagedType.LPWStr )] string key, int defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is int )
                defaultValue = ( int )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetFloatDelegate ) )]
        private static float OnGetFloat([MarshalAs( UnmanagedType.LPWStr )] string key, float defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is float )
                defaultValue = ( float )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetStringDelegate ) )]
        [return: MarshalAs( UnmanagedType.LPWStr )]
        private static string OnGetString(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string defaultValue)
        {
            object obj;
            if( _storage.TryGetValue( key, out obj ) && obj is string )
                defaultValue = ( string )obj;
            Dbg.Log( "Get[{0}] = {1}", key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( HasKeyDelegate ) )]
        private static bool OnHasKey([MarshalAs( UnmanagedType.LPWStr )] string key)
        {
            var hasKey = _storage.ContainsKey( key );
            Dbg.Log( "HasKey[{0}]? {1}", key, hasKey );
            return hasKey;
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteKeyDelegate ) )]
        private static void OnDeleteKey([MarshalAs( UnmanagedType.LPWStr )] string key)
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

#endif
    }
}
