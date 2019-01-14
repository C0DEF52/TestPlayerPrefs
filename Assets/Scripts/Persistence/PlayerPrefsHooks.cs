//#define ENABLE_IL2CPP
//#define ENABLE_PLAYER_PREFS_HOOKS

#if ENABLE_PLAYER_PREFS_HOOKS

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fiftytwo
{
    public static class PlayerPrefsHooks
    {
        public delegate bool TrySetIntDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key, int value );
        public delegate bool TrySetFloatDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key, float value );
        public delegate bool TrySetStringDelegate (
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string value );
        public delegate int GetIntDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key, int defaultValue );
        public delegate float GetFloatDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key, float defaultValue );
        [return: MarshalAs( UnmanagedType.LPWStr )]
        public delegate string GetStringDelegate (
            [MarshalAs( UnmanagedType.LPWStr )] string key, [MarshalAs( UnmanagedType.LPWStr )] string defaultValue );
        public delegate bool HasKeyDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key);
        public delegate void DeleteKeyDelegate ( [MarshalAs( UnmanagedType.LPWStr )] string key );
        public delegate void DeleteAllDelegate ();
        public delegate void SaveDelegate ();


        public static TrySetIntDelegate TrySetInt;
        public static TrySetFloatDelegate TrySetFloat;
        public static TrySetStringDelegate TrySetString;
        public static GetIntDelegate GetInt;
        public static GetFloatDelegate GetFloat;
        public static GetStringDelegate GetString;
        public static HasKeyDelegate HasKey;
        public static DeleteKeyDelegate DeleteKey;
        public static DeleteAllDelegate DeleteAll;
        public static SaveDelegate Save;


        public static void Initialize ()
        {
            var callbacks = 
#if ENABLE_IL2CPP
                new Callbacks
                {
                    TrySetInt = OnTrySetInt,
                    TrySetFloat = OnTrySetFloat,
                    TrySetString = OnTrySetString,
                    GetInt = OnGetInt,
                    GetFloat = OnGetFloat,
                    GetString = OnGetString,
                    HasKey = OnHasKey,
                    DeleteKey = OnDeleteKey,
                    DeleteAll = OnDeleteAll,
                    Save = OnSave,
                };
#else
                default( Callbacks );
#endif
            Initialize( callbacks );
        }

        public static void Initialize ( Callbacks callbacks )
        {
#if ENABLE_IL2CPP
            _callbacks = callbacks;
            Fiftytwo_PlayerPrefsHooks_SetCallbacks( callbacks );
#else
            Debug.LogAssertion( "IL2CPP is disabled" );
#endif
        }


        [StructLayout( LayoutKind.Sequential )]
        public struct Callbacks
        {
            public TrySetIntDelegate TrySetInt;
            public TrySetFloatDelegate TrySetFloat;
            public TrySetStringDelegate TrySetString;
            public GetIntDelegate GetInt;
            public GetFloatDelegate GetFloat;
            public GetStringDelegate GetString;
            public HasKeyDelegate HasKey;
            public DeleteKeyDelegate DeleteKey;
            public DeleteAllDelegate DeleteAll;
            public SaveDelegate Save;
        }


#if ENABLE_IL2CPP

        private static Callbacks _callbacks;


        [DllImport("__Internal")]
        private static extern void Fiftytwo_PlayerPrefsHooks_SetCallbacks ( Callbacks callbacks );


        [AOT.MonoPInvokeCallback( typeof( TrySetIntDelegate ) )]
        private static bool OnTrySetInt ( string key, int value )
        {
            if( TrySetInt != null )
                return TrySetInt( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetFloatDelegate ) )]
        private static bool OnTrySetFloat ( string key, float value )
        {
            if( TrySetFloat != null )
                return TrySetFloat( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( TrySetStringDelegate ) )]
        private static bool OnTrySetString ( string key, string value )
        {
            if( TrySetString != null )
                return TrySetString( key, value );
            return true;
        }

        [AOT.MonoPInvokeCallback( typeof( GetIntDelegate ) )]
        private static int OnGetInt ( string key, int defaultValue )
        {
            if( GetInt != null )
                return GetInt( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetFloatDelegate ) )]
        private static float OnGetFloat ( string key, float defaultValue )
        {
            if( GetFloat != null )
                return GetFloat( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( GetStringDelegate ) )]
        private static string OnGetString ( string key, string defaultValue )
        {
            if( GetString != null )
                return GetString( key, defaultValue );
            return defaultValue;
        }

        [AOT.MonoPInvokeCallback( typeof( HasKeyDelegate ) )]
        private static bool OnHasKey ( string key )
        {
            if( HasKey != null )
                return HasKey( key );
            return false;
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteKeyDelegate ) )]
        private static void OnDeleteKey ( string key )
        {
            if( DeleteKey != null )
                DeleteKey( key );
        }

        [AOT.MonoPInvokeCallback( typeof( DeleteAllDelegate ) )]
        private static void OnDeleteAll ()
        {
            if( DeleteAll != null )
                DeleteAll();
        }

        [AOT.MonoPInvokeCallback( typeof( SaveDelegate ) )]
        private static void OnSave ()
        {
            if( Save != null )
                Save();
        }

#endif
    }
}

#endif
