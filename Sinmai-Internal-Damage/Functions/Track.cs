using MAI2.Util;
using Manager;
using System.Reflection;
using UnityEngine;
using Monitor;

namespace Sinmai.Functions
{
    public class Track : MonoBehaviour
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;
        
        public static void ForceTrackSkip(int monitor)
        {
            // set track skip flag
            Singleton<GamePlayManager>.Instance.SetTrackSkipFrag(monitor);

            // play animation
            // get PlayAnim method from TrackSkip
            MethodInfo playanim = typeof(TrackSkip).GetMethod("PlayAnim", iBindFlags | pBindFlags);

            // get TrackSkip instance
            TrackSkip[] trackskips = Resources.FindObjectsOfTypeAll<TrackSkip>();
            foreach( TrackSkip trackskip in trackskips )
            {
                if((int)typeof(TrackSkip).GetField("_monitorIndex", pBindFlags | iBindFlags).GetValue(trackskip) == monitor)
                {
                    // invoke PlayAnim
                    playanim.Invoke(trackskip, null);
                }
            }

        }
    }
}