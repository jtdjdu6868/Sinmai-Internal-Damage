namespace Sinmai.Helper
{
    class Settings
    {
        public static string Version = "b20231111-A";
        public static string GameVersion = Sinmai.Functions.Version.CheckClientVersion();

        public static int MainToolbarInt = 0;
        public static string[] MainToolbarStrings = { "Legit", "Misc" };


        // Legit Autoplay
        public static bool LegitAutoPlayCheckBox = false;
        public static int LegitMethodInt = 0;
        public static string[] LegitMethod = {"Weighted", "Native"};
        public static float CriticalValue = 100.0f;
        public static float PerfectValue = 0.0f;
        public static float GreatValue = 0.0f;
        public static float GoodValue = 0.0f;
        public static float MissValue = 0.0f;

        public static bool CriticalToggle = true;
        public static bool PerfectToggle = false;
        public static bool GreatToggle = false;
        public static bool GoodToggle = false;
        public static bool MissToggle = false;


        // Rage Autoplay

        // Some cool part idk

        // Misc
        public static bool InfinityFreedomTimeCheckBox = false;
        public static bool InfinityPrepareTimeCheckBox = false;

    }
}
