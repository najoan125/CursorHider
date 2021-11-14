using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdofaiFirstMod.MainPatch
{
    [HarmonyPatch(typeof(scrController), "PlayerControl_Update")]
    internal static class HideCursor
    {
        [HarmonyPatch(typeof(scrController), "FailAction")]
        private static void Prefix()
        {

        }
        private static void Postfix()
        {
            bool playing = !scrController.instance.paused && scrConductor.instance.isGameWorld;
            if (!scrController.instance.paused && scrConductor.instance.isGameWorld && !Main.Hiden)
            {
                Main.ShowCursor(false);
                Main.Hiden = true;
            }
            else if (!playing && Main.Hiden)
            {
                Main.ShowCursor(true);
                Main.Hiden = false;
            }
        }
    }
}
