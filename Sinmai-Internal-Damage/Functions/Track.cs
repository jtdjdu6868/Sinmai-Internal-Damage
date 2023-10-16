using MAI2.Util;
using Manager;
using System.Reflection;
using UnityEngine;
using Mai2.Mai2Cue;

namespace Sinmai.Functions
{
    public class Track
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;
        
        public static void ForceTrackSkip()
        {
            // skip 1p
            Singleton<GamePlayManager>.Instance.SetTrackSkipFrag(0);
            SoundManager.PlaySE(Cue.SE_GAME_TRACK_SKIP, 0);

        }
    }
}