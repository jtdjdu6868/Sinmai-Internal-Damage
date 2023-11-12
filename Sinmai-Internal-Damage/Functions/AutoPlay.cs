using Manager;
using Sinmai.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System;
using HarmonyLib;

namespace Sinmai.Functions
{

    [HarmonyPatch(typeof(GameManager))]
    [HarmonyPatch("AutoJudge")]
    class WeightedRandomAutoJudge
    {
        public static bool Prefix(ref NoteJudge.ETiming __result)
        {
            if(Settings.LegitAutoPlayCheckBox && Settings.LegitMethodInt == Settings.LegitMethod.Weighted)
            {
                __result = WeightedRamdom();
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void Postfix(ref NoteJudge.ETiming __result)
        {
            
        }
        public static NoteJudge.ETiming WeightedRamdom()
        {
            int totalWeight = (int)(Settings.CriticalValue + Settings.PerfectValue + Settings.GreatValue + Settings.GoodValue + Settings.MissValue);
            int rand = new Random().Next(0, totalWeight);

            if (rand >= 0 && rand < Settings.CriticalValue)
            {
                return NoteJudge.ETiming.Critical;
            }
            else if (rand >= Settings.CriticalValue && rand < Settings.CriticalValue + Settings.PerfectValue)
            {
                return NoteJudge.ETiming.LatePerfect2nd;
            }
            else if (rand >= Settings.CriticalValue + Settings.PerfectValue && rand < Settings.CriticalValue + Settings.PerfectValue + Settings.GreatValue)
            {
                return NoteJudge.ETiming.LateGreat;
            }
            else if (rand >= Settings.CriticalValue + Settings.PerfectValue + Settings.GreatValue && rand < Settings.CriticalValue + Settings.PerfectValue + Settings.GreatValue + Settings.GoodValue)
            {
                return NoteJudge.ETiming.LateGood;
            }
            else
            {
                return NoteJudge.ETiming.TooLate;
            }
        }
    }
    [HarmonyPatch(typeof(GameManager))]
    [HarmonyPatch("IsAutoPlay")]
    class IsAutoPlay
    {
        public static void Postfix(ref bool __result)
        {
            __result |= (Settings.LegitAutoPlayCheckBox && Settings.LegitMethodInt == Settings.LegitMethod.Weighted);
        }
    }
    public class AutoPlay
    {
        private const BindingFlags pBindFlags = BindingFlags.NonPublic;
        private const BindingFlags iBindFlags = BindingFlags.Instance;
        private const BindingFlags sBindFlags = BindingFlags.Static;

        public static void PatchAutoPlay()
        {
            try
            {
                var harmony = new Harmony("Sinmai.InternalDamage");


                MethodInfo autojudge = typeof(GameManager).GetMethod("AutoJudge", sBindFlags | BindingFlags.Public);
                MethodInfo autojudgePrefix = typeof(WeightedRandomAutoJudge).GetMethod("Prefix", sBindFlags | BindingFlags.Public);
                MethodInfo autojudgePostfix = typeof(WeightedRandomAutoJudge).GetMethod("Postfix", sBindFlags | BindingFlags.Public);

                harmony.Patch(autojudge, new HarmonyMethod(autojudgePrefix), new HarmonyMethod(autojudgePostfix));

                MethodInfo isautoplay = typeof(GameManager).GetMethod("IsAutoPlay", sBindFlags | BindingFlags.Public);
                // MethodInfo isautoplayPrefix = typeof(IsAutoPlay).GetMethod("Prefix", sBindFlags | BindingFlags.Public);
                MethodInfo isautoplayPostfix = typeof(IsAutoPlay).GetMethod("Postfix", sBindFlags | BindingFlags.Public);

                harmony.Patch(isautoplay, null, new HarmonyMethod(isautoplayPostfix));
            }
            catch(Exception e)
            {
                Settings.log += e.Message;
                Settings.log += e.StackTrace;
            }
        }

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