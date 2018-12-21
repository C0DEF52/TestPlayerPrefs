using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fiftytwo
{
    [CreateAssetMenu( menuName = "Fiftytwo/Log Data", fileName = "LogData" )]
    public class LogData : ScriptableObject
    {
        public bool RestrictLogCount = false;
        public int MaxLogCount = 1000;
        [NonSerialized]
        public List<Log> Logs = new List<Log>();

        private bool _initialized;

        public void Initialize ()
        {
            if( _initialized )
                return;

#if UNITY_EDITOR
            if( !UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode )
                return;
#endif

            Application.logMessageReceived += HandleLog;
            _initialized = true;
        }

        public void Uninitialize ()
        {
            if( !_initialized )
                return;

            Application.logMessageReceived -= HandleLog;
            _initialized = false;
        }

        public void Clear ()
        {
            Logs.Clear();
        }

        private void HandleLog ( string message, string stackTrace, LogType type )
        {
            var count = Logs.Count;
            if( count == 0 )
            {
                Logs.Add( new Log { Count = 1, Message = message, StackTrace = stackTrace, Type = type } );
            }
            else
            {
                var log = Logs[count - 1];
                if( log.Type == type && log.Message == message && log.StackTrace == stackTrace )
                    ++log.Count;
                else
                    Logs.Add( new Log { Count = 1, Message = message, StackTrace = stackTrace, Type = type } );

                if( RestrictLogCount && count > MaxLogCount )
                    Logs.RemoveRange( MaxLogCount, count - MaxLogCount );
            }
        }

        public class Log
        {
            public int Count;
            public string Message;
            public string StackTrace;
            public LogType Type;

            public bool Equals ( Log log )
            {
                return Message == log.Message && StackTrace == log.StackTrace && Type == log.Type;
            }
        }
    }
}
