#if ENABLE_FS_PREFS_PROVIDER

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
    public class FsPrefsFlusher : MonoBehaviour
    {
        [SerializeField]
        public float FlushPeriod = 30f;

        private FsPrefsProvider _provider;

        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.AfterSceneLoad )]
        private static void Create ()
        {
#if !UNITY_EDITOR
            var flusher = new GameObject( "FS Prefs Flusher", typeof( FsPrefsFlusher ) );
            DontDestroyOnLoad( flusher );
#endif
        }

        private void Awake ()
        {
            _provider = ( FsPrefsProvider )Persistence.Player;
        }

        private IEnumerator Start ()
        {
            var wait = new WaitForSeconds( FlushPeriod );
            while( true )
            {
                yield return wait;
                _provider.Flush();
            }
        }

        private void OnApplicationQuit ()
        {
            _provider.Flush();
        }
    }
}

#endif
