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
        public delegate void SetStringDelegate(
            [MarshalAs(UnmanagedType.LPWStr)] string key,
            [MarshalAs(UnmanagedType.LPWStr)] string value );

        private static readonly SetStringDelegate _setString = OnSetString;

        public static void InstallHooks ()
        {
            InstallHooks( _setString );
        }

        [DllImport("__Internal")]
        private static extern void InstallHooks( SetStringDelegate setString );
        //[DllImport("__Internal")]
        //public static extern int CountLettersInString(
        //    [MarshalAs(UnmanagedType.LPWStr)] string str,
        //    [MarshalAs(UnmanagedType.LPWStr)] string str2 );

        [DllImport("__Internal")]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string ProcessString([MarshalAs(UnmanagedType.LPWStr)] string str);

        private static void OnSetString ( string key, string value )
        {

        }
    }
}

#endif
