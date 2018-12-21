
namespace Fiftytwo
{
    public static class Persistence
    {
        public static IPrefsProvider Player { get; private set; }

#if UNITY_EDITOR
        public static IPrefsProvider Editor { get; private set; }
#endif

        static Persistence ()
        {
#if UNITY_SWITCH && !UNITY_EDITOR
            Player = new SwitchPrefsProvider();
#else
            Player = new PlayerPrefsProvider();
#endif

#if UNITY_EDITOR
            Editor = new EditorPrefsProvider();
#endif
        }
    }
}
