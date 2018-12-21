#if UNITY_SWITCH && !UNITY_EDITOR

using System.Collections;
using UnityEngine;
using UnityEngine.Switch;

namespace Fiftytwo
{
    public class SwitchPrefsFlusher : MonoBehaviour
    {
        [SerializeField]
        public float FlushPeriod = 30f;

        private SwitchPrefsProvider _provider;

        private void Awake ()
        {
            _provider = ( SwitchPrefsProvider )Persistence.Player;

            Notification.EnterExitRequestHandlingSection();

            Notification.SetFocusHandlingMode(
                Notification.FocusHandlingMode.SuspendAndNotify );
            Notification.notificationMessageReceived += OnNotificationMessageReceived;
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

        private void OnNotificationMessageReceived ( Notification.Message message )
        {
            switch( message )
            {
                case Notification.Message.ExitRequest:
                    Dbg.Log( "=== Notification.Message.ExitRequest ===" );
                    _provider.Flush();
                    Notification.LeaveExitRequestHandlingSection();
                    break;
            }
        }
    }
}

#endif
