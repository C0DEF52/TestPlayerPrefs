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
        private static void DisablePlayerPrefs ()
        {
#if ENABLE_IL2CPP
            PlayerPrefsHooks.SetCallbacks();
#endif
        }
    }
}
