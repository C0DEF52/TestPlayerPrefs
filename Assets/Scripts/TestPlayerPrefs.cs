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
        private int _counter;

        private void Awake ()
        {
        }

        private void OnDestroy ()
        {
        }

        private void Start ()
        {
            PlayerPrefs.SetString( "StringKey", "Строковое значение" );
            PlayerPrefs.SetInt( "IntKey", 1100 );
            PlayerPrefs.SetFloat( "FloatKey", 3.14f );

            PlayerPrefs.Save();

            Dbg.Log( "StringKey={0}", PlayerPrefs.GetString( "StringKey", "Empty" ) );
            Dbg.Log( "IntKey={0}", PlayerPrefs.GetInt( "IntKey", -1 ) );
            Dbg.Log( "FloatKey={0}", PlayerPrefs.GetFloat( "FloatKey", 2.71f ) );
        }
    }
}
