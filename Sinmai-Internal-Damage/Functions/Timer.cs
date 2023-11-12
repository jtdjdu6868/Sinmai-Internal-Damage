using System.Reflection;
using Manager;
using Sinmai.Helper;

namespace Sinmai.Functions
{
    public class Timer
    {
        private static readonly BindingFlags pBindFlags = BindingFlags.NonPublic;
        private static readonly BindingFlags iBindFlags = BindingFlags.Instance;
        private static readonly BindingFlags sBindFlags = BindingFlags.Static;
        private static bool IsInfinityFreedomTime = false;
        public static void InfinityFreedomTime()
        {
            if(Settings.InfinityFreedomTimeCheckBox && !IsInfinityFreedomTime)
            {
                PauseFreedomTimer();
                IsInfinityFreedomTime = true;
            }
            else if(!Settings.InfinityFreedomTimeCheckBox && IsInfinityFreedomTime)
            {
                ResumeFreedomTimer();
                IsInfinityFreedomTime = false;
            }
        }
        public static void PauseFreedomTimer()
        {
            GameManager.PauseFreedomModeTimer(true);

            var gameManagerType = typeof(GameManager);
            var freedomTime = gameManagerType.GetField("_freedomTime", sBindFlags | pBindFlags);

            freedomTime.SetValue(null, 600000L);
        }

        public static void ResumeFreedomTimer()
        {
            GameManager.PauseFreedomModeTimer(false);
        }

        public static void InfinityPrepareTime()
        {
            if (!Settings.InfinityFreedomTimeCheckBox)
                return;
        }

    }
}
