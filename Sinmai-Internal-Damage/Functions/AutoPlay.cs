using Manager;
using Sinmai.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Sinmai.Functions
{
    public class AutoPlay
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;
        

        public static void FullRandom()
        {
            List<NoteJudge.ETiming> randSet = new List<NoteJudge.ETiming>();
            if(Settings.CriticalToggle)
            {
                randSet.Add(NoteJudge.ETiming.Critical);
            }
            if(Settings.PerfectToggle)
            {
                randSet.Add(NoteJudge.ETiming.LatePerfect);
            }
            if(Settings.GreatToggle)
            {
                randSet.Add(NoteJudge.ETiming.LateGreat);
            }
            if(Settings.GoodToggle)
            {
                randSet.Add(NoteJudge.ETiming.LateGood);
            }
            if(Settings.MissToggle)
            {
                randSet.Add(NoteJudge.ETiming.TooLate);
            }
            if(randSet.Count == 0)
            {
                randSet.Add(NoteJudge.ETiming.TooLate);
            }
            typeof(GameManager).GetField("RandTiming", pBindFlags | sBindFlags).SetValue(null, new ReadOnlyCollection<NoteJudge.ETiming>(randSet));
        }
    }
}