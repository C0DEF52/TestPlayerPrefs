using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Fiftytwo
{
    public class TestPlayerPrefs : MonoBehaviour
    {
        private string _str;
        private int _counter;

        private void Awake ()
        {
//#if ENABLE_IL2CPP
            Dbg.Log( "Install hooks from Awake()" );
            PlayerPrefsHooks.InstallHooks();
//#endif
            _str = "RПривет, 👨🏽 !!!";
            _str = _str.Substring(1);
            Dbg.Log( "Going to process \"{0}\" with length {1}", _str, _str.Length );
            _str = PlayerPrefsHooks.ProcessString(_str);
            Dbg.Log( "Str={0}", _str );
        }

        private void OnDestroy ()
        {
        }

        private IEnumerator Start ()
        {
            PlayerPrefs.SetString( "StringKey", "Строковое значение" );
            PlayerPrefs.SetInt( "IntKey", 1100 );
            PlayerPrefs.SetFloat( "FloatKey", 3.14f );

            PlayerPrefs.Save();

            Dbg.Log( "StringKey={0}", PlayerPrefs.GetString( "StringKey", "Empty" ) );
            Dbg.Log( "IntKey={0}", PlayerPrefs.GetInt( "IntKey", -1 ) );
            Dbg.Log( "FloatKey={0}", PlayerPrefs.GetFloat( "FloatKey", 2.71f ) );

            while( true )
            {
                Dbg.Log( "_str[{0}]={1}", ++_counter, _str );
                yield return new WaitForSecondsRealtime( 1 );
            }
        }
    }
}
