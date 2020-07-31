using BS_Utils.Utilities;


namespace NoteDebrisRedux
{
    public static class Settings
    {
        internal static Config cfgProvider = new Config("NoteDebrisRedux");
        public static bool _isModEnabled;

        static Settings()
        {
            Load();
        }

        public static void Load()
        {
            _isModEnabled = cfgProvider.GetBool("NoteDebrisRedux", nameof(_isModEnabled), true, true);
        }

        public static void Save()
        {
            cfgProvider.SetBool("NoteDebrisRedux", nameof(_isModEnabled), _isModEnabled);
        }
    }
}