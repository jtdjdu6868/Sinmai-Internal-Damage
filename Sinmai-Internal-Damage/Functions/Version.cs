using MAI2System;
using System.Reflection;

namespace Sinmai.Functions
{
    public class Version
    {
        public static string CheckClientVersion()
        {
            var GameIDStr = typeof(ConstParameter).GetField("GameIDStr", BindingFlags.Public | BindingFlags.Static).GetValue(null);
            var NowGameVersion = typeof(ConstParameter).GetField("NowGameVersion", BindingFlags.Public | BindingFlags.Static).GetValue(null);
            return GameIDStr + " " + NowGameVersion;
        }
    }
}
