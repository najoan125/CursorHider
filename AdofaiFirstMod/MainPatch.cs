using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityModManagerNet;

namespace AdofaiFirstMod.MainPatch
{
    public static class Patches
    {
        [HarmonyPatch(typeof(scnEditor),"Play")]
        public static class PlayPatch
        {
            public static void Prefix()
            {
                Main.SettingEditorShow = true;
            }
        }
    }
}
