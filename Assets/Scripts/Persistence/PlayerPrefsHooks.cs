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
        public delegate bool TrySetIntDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, int value);
        public delegate bool TrySetFloatDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, float value);
        public delegate bool TrySetSetStringDelegate(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string value);
        public delegate int GetIntDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, int defaultValue);
        public delegate float GetFloatDelegate([MarshalAs( UnmanagedType.LPWStr )] string key, float defaultValue);
        [return: MarshalAs( UnmanagedType.LPWStr )]
        public delegate  string GetStringDelegate(
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string defaultValue);
        public delegate bool HasKeyDelegate([MarshalAs( UnmanagedType.LPWStr )] string key);
        public delegate void DeleteKeyDelegate([MarshalAs( UnmanagedType.LPWStr )] string key);
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


        [DllImport("__Internal")]
        private static extern void Fiftytwo_PlayerPrefsHooks_SetCallbacks( Callbacks callbacks );


        [AOT.MonoPInvokeCallback( typeof( TrySetIntDelegate ) )]
        private static bool OnTrySetInt(string key, int value)
        {
            if( TrySetInt != null )
                return TrySetInt( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetFloatDelegate ) )]
        private static bool OnTrySetFloat(string key, float value)
        {
            if( TrySetFloat != null )
                return TrySetFloat( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetSetStringDelegate ) )]
        private static bool OnTrySetSetString(string key, string value)
        {
            if( TrySetSetString != null )
                return TrySetSetString( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( GetIntDelegate ) )]
        private static int OnGetInt(string key, int defaultValue)
        {
            if( GetInt != null )
                return GetInt( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetFloatDelegate ) )]
        private static float OnGetFloat(string key, float defaultValue)
        {
            if( GetFloat != null )
                return GetFloat( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetStringDelegate ) )]
        private static string OnGetString(string key, string defaultValue)
        {
            if( GetString != null )
                return GetString( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( HasKeyDelegate ) )]
        private static bool OnHasKey(string key)
        {
            if( HasKey != null )
                return HasKey( key );
            return false;
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteKeyDelegate ) )]
        private static void OnDeleteKey(string key)
        {
            if( DeleteKey != null )
                DeleteKey( key );
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteAllDelegate ) )]
        private static void OnDeleteAll()
        {
            if( DeleteAll != null )
                DeleteAll();
        }

        [AOT.MonoPInvokeCallback( typeof( SaveDelegate ) )]
        private static void OnSave()
        {
            if( Save != null )
                Save();
        }

#endif
    }
}
