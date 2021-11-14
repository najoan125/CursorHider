using System;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace AdofaiFirstMod
{
	// Token: 0x02000002 RID: 2
	internal static class Main
	{
		public static bool Hiden = false;
		[DllImport("user32.dll")]
		public static extern int ShowCursor(bool bShow);
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		internal static bool IsEnabled { get; private set; }

		// Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
		private static void Setup(UnityModManager.ModEntry modEntry)
		{
			Main.Mod = modEntry;
			Main.Mod.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
			Main.Mod.OnUpdate = new Action<UnityModManager.ModEntry, float>(Main.OnUpdate);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002080 File Offset: 0x00000280
		private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
		{
			Main.IsEnabled = value;
			if (value)
			{
				Main.Start();
			}
			else
			{
				Main.Stop();
			}
			return true;
		}

		private static void OnUpdate(UnityModManager.ModEntry modentry, float deltaTime)
        {
			if (!scrController.instance || !scrConductor.instance)
            {
				return;
            }
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

		// Token: 0x06000005 RID: 5 RVA: 0x000020B4 File Offset: 0x000002B4
		private static void Start()
		{
			Main._harmony = new Harmony(Main.Mod.Info.Id);
			Main._harmony.PatchAll(Assembly.GetExecutingAssembly());
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002105 File Offset: 0x00000305
		private static void Stop()
		{
			Main._harmony.UnpatchAll(Main.Mod.Info.Id);
			Main._harmony = null;
		}

		// Token: 0x04000002 RID: 2

		// Token: 0x04000003 RID: 3
		internal static UnityModManager.ModEntry Mod;

		// Token: 0x04000004 RID: 4
		private static Harmony _harmony;
    }
}
