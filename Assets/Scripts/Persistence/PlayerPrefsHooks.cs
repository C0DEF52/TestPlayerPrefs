#if ENABLE_IL2CPP

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
        [DllImport("__Internal")]
        public static extern void InstallHooks();
        //[DllImport("__Internal")]
        //public static extern int CountLettersInString(
        //    [MarshalAs(UnmanagedType.LPWStr)] string str,
        //    [MarshalAs(UnmanagedType.LPWStr)] string str2 );
    }
}

#endif
