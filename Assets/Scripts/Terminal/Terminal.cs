using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fiftytwo
{
    public class Terminal : MonoBehaviour
    {
        private static readonly GUIContent ClearLabel = new GUIContent( "Clear", "Clear the contents of the console." );
        private static readonly GUIContent CollapseLabel = new GUIContent( "Collapse", "Hide repeated messages." );
        private const int Margin = 10;
        private const string WindowTitle = "Terminal";

        private static readonly Dictionary<LogType, Color> LogTypeColors = new Dictionary<LogType, Color>
        {
            { LogType.Assert, Color.white },
            { LogType.Error, Color.red },
            { LogType.Exception, Color.red },
            { LogType.Log, Color.white },
            { LogType.Warning, Color.yellow },
        };

        public LogData LogData;

        private bool _isCollapsed;
        private Vector2 _scrollPosition;

        private readonly Dictionary<LogType, bool> _logTypeFilters = new Dictionary<LogType, bool>
        {
            { LogType.Assert, true },
            { LogType.Error, true },
            { LogType.Exception, true },
            { LogType.Log, true },
            { LogType.Warning, true },
        };

        public void Toggle ()
        {
            enabled = !enabled;
        }

        private void OnGUI ()
        {
            var rc = new Rect( Margin, Margin, Screen.width - ( Margin * 2 ), Screen.height - ( Margin * 2 ) );
            GUILayout.Window( 0, rc, DrawWindow, WindowTitle );
        }

        private void DrawWindow ( int windowID )
        {
            DrawLogList();
            DrawToolbar();

            // Allow the window to be dragged by its title bar.
            //GUI.DragWindow( _titleBarRect );
        }

        private void DrawLogList ()
        {
            _scrollPosition = GUILayout.BeginScrollView( _scrollPosition );

            // Used to determine height of accumulated log labels.
            GUILayout.BeginVertical();

            if( LogData != null )
            {
                var visibleLogs = LogData.Logs.Where( ( l ) => _logTypeFilters[l.Type] );

                foreach( var log in visibleLogs )
                {
                    DrawLog( log );
                }
            }

            GUILayout.EndVertical();
            var innerScrollRect = GUILayoutUtility.GetLastRect();
            GUILayout.EndScrollView();
            var outerScrollRect = GUILayoutUtility.GetLastRect();

            // If we're scrolled to bottom now, guarantee that it continues to be in next cycle.
            if( Event.current.type == EventType.Repaint && IsScrolledToBottom( innerScrollRect, outerScrollRect ) )
            {
                ScrollToBottom();
            }

            // Ensure GUI colour is reset before drawing other components.
            GUI.contentColor = Color.white;
        }

        private void DrawLog ( LogData.Log log )
        {
            GUI.contentColor = LogTypeColors[log.Type];

            if( _isCollapsed )
            {
                DrawCollapsedLog( log );
            }
            else
            {
                DrawExpandedLog( log );
            }
        }

        private void DrawCollapsedLog ( LogData.Log log )
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label( log.Message );
            GUILayout.FlexibleSpace();
            GUILayout.Label( log.Count.ToString(), GUI.skin.box );

            GUILayout.EndHorizontal();
        }

        private void DrawExpandedLog ( LogData.Log log )
        {
            for( var i = 0; i < log.Count; i += 1 )
            {
                GUILayout.Label( log.Message );
            }
        }

        private bool IsScrolledToBottom ( Rect innerScrollRect, Rect outerScrollRect )
        {
            var innerScrollHeight = innerScrollRect.height;

            // Take into account extra padding added to the scroll container.
            var outerScrollHeight = outerScrollRect.height - GUI.skin.box.padding.vertical;

            // If contents of scroll view haven't exceeded outer container, treat it as scrolled to bottom.
            if( outerScrollHeight > innerScrollHeight )
            {
                return true;
            }

            // Scrolled to bottom (with error margin for float math)
            return Mathf.Approximately( innerScrollHeight, _scrollPosition.y + outerScrollHeight );
        }

        private void ScrollToBottom ()
        {
            _scrollPosition = new Vector2( 0, Int32.MaxValue );
        }

        private void DrawToolbar ()
        {
            GUILayout.BeginHorizontal();

            if( GUILayout.Button( ClearLabel ) )
            {
                if( LogData != null )
                    LogData.Clear();
            }

            foreach( LogType logType in Enum.GetValues( typeof( LogType ) ) )
            {
                var currentState = _logTypeFilters[logType];
                var label = logType.ToString();
                _logTypeFilters[logType] = GUILayout.Toggle( currentState, label, GUILayout.ExpandWidth( false ) );
                GUILayout.Space( 20 );
            }

            _isCollapsed = GUILayout.Toggle( _isCollapsed, CollapseLabel, GUILayout.ExpandWidth( false ) );

            GUILayout.EndHorizontal();
        }
    }
}
