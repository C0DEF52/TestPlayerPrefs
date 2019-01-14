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
    public abstract class DictionaryPrefsProvider : IPrefsProvider
    {
        protected Dictionary<string, object> _data;

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
#if UNITY_EDITOR
            Flush();
#endif
        }

        public int GetInt( string key, int defaultValue = 0 )
        {
            object result = null;
            if( !_data.TryGetValue( key, out result ) )
                return defaultValue;
            return ( int )result;
        }

        public void SetInt( string key, int value )
        {
            _data[key] = value;
#if UNITY_EDITOR
            Flush();
#endif
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
#if UNITY_EDITOR
            Flush();
#endif
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
#if UNITY_EDITOR
            Flush();
#endif
        }

        public bool HasKey ( string key )
        {
            return _data.ContainsKey( key );
        }

        public void DeleteKey ( string key )
        {
            _data.Remove( key );
#if UNITY_EDITOR
            Flush();
#endif
        }

        public void DeleteAll()
        {
            _data.Clear();
#if UNITY_EDITOR
            Flush();
#endif
        }

        public abstract void Flush ();
    }
}
