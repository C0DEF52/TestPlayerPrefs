﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

namespace Fiftytwo
{
    public class PlayerPrefsProvider : IPrefsProvider
    {
        public bool GetBool( string key, bool defaultValue = false )
        {
            return PlayerPrefs.GetInt( key, defaultValue ? 1 : 0 ) != 0;
        }

        public void SetBool( string key, bool value )
        {
            PlayerPrefs.SetInt( key, value ? 1 : 0 );
            PlayerPrefs.Save();
        }

        public int GetInt( string key, int defaultValue = 0 )
        {
            return PlayerPrefs.GetInt( key, defaultValue );
        }

        public void SetInt( string key, int value )
        {
            PlayerPrefs.SetInt( key, value );
            PlayerPrefs.Save();
        }

        public float GetFloat( string key, float defaultValue = 0.0f )
        {
            return PlayerPrefs.GetFloat( key, defaultValue );
        }

        public void SetFloat( string key, float value )
        {
            PlayerPrefs.SetFloat( key, value );
            PlayerPrefs.Save();
        }

        public string GetString( string key, string defaultValue = "" )
        {
            return PlayerPrefs.GetString( key, defaultValue );
        }

        public void SetString( string key, string value )
        {
            PlayerPrefs.SetString( key, value );
            PlayerPrefs.Save();
        }

        public bool HasKey ( string key )
        {
            return PlayerPrefs.HasKey( key );
        }

        public void DeleteKey ( string key )
        {
            PlayerPrefs.DeleteKey( key );
            PlayerPrefs.Save();
        }

        public void DeleteAll ()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
