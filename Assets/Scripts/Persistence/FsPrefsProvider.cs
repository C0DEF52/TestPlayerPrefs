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
//using UnityEditor;
//using Newtonsoft.Json;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Fiftytwo
{
    public class FsPrefsProvider : DictionaryPrefsProvider
    {
        protected override void SerializeData ( Dictionary<string, object> data )
        {
            //var jsonText = JsonConvert.SerializeObject( data, Formatting.Indented );

            //Dbg.Log( "Flush Prefs: " + jsonText );
        }

        protected override Dictionary<string, object> DeserializeData ()
        {
            return new Dictionary<string, object>();
        }

        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void HookPlayerPrefs ()
        {
#if ENABLE_IL2CPP
            var me = ( FsPrefsProvider )Persistence.Player;
            PlayerPrefsHooks.TrySetInt = me.TrySetInt;
            PlayerPrefsHooks.TrySetFloat = me.TrySetFloat;
            PlayerPrefsHooks.TrySetString = me.TrySetString;
            PlayerPrefsHooks.GetInt = me.GetInt;
            PlayerPrefsHooks.GetFloat = me.GetFloat;
            PlayerPrefsHooks.GetString = me.GetString;
            PlayerPrefsHooks.HasKey = me.HasKey;
            PlayerPrefsHooks.DeleteKey = me.DeleteKey;
            PlayerPrefsHooks.DeleteAll = me.DeleteAll;
            PlayerPrefsHooks.Initialize();
#endif
        }

        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.AfterSceneLoad )]
        private static void CreateFlusher ()
        {
        }

        private bool TrySetInt ( string key, int value )
        {
            SetInt( key, value );
            return true;
        }

        private bool TrySetFloat ( string key, float value )
        {
            SetFloat( key, value );
            return true;
        }

        private bool TrySetString ( string key, string value )
        {
            SetString( key, value );
            return true;
        }
    }
}
