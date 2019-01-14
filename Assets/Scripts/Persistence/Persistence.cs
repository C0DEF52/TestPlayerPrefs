//#define ENABLE_FS_PREFS_PROVIDER

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
#if UNITY_EDITOR
            Player = new PlayerPrefsProvider();
#elif UNITY_SWITCH
            Player = new SwitchPrefsProvider();
#elif ENABLE_FS_PREFS_PROVIDER
            Player = new FsPrefsProvider();
#else
            Player = new PlayerPrefsProvider();
#endif

#if UNITY_EDITOR
            Editor = new EditorPrefsProvider();
#endif
        }
    }
}
