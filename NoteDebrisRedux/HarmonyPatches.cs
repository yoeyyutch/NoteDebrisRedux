
using HarmonyLib;
using System;
using UnityEngine;


namespace NoteDebrisRedux.HarmonyPatches
{
    [HarmonyPatch(typeof(NoteDebris))]
    [HarmonyPatch("Init")]
    [HarmonyPatch(new Type[] {typeof(float)})]
    class NoteDebrisInitPatch
    {
        static void Prefix(ref float lifetime)
        {
            lifetime = 0f;
            return;
        }
    }
}