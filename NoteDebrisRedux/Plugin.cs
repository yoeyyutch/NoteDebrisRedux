using IPA.Utilities;
using IPA;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;
using UnityEngine;
using System.IO;

namespace NoteDebrisRedux
{

	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		internal static string PluginName => "NoteDebrisRedux";
		readonly string songStatsDirectory = Path.Combine(UnityGame.UserDataPath, PluginName);
		public string Version => "1.3.2";



		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.NoteDebrisRedux";

		internal static bool harmonyPatchesLoaded = false;

		internal static readonly Harmony harmonyInstance = new Harmony(HARMONYID);

		//public static Vector3 DebrisForceMultiplier { get; private set; } = new Vector3(Config.VelocityMultiplierX, Config.VelocityMultiplierY, Config.VelocityMultiplierZ);


		public static bool ModEnabled { get; private set; } = Config.MODENABLED;
		public static float DebrisForceX { get; private set; } = Config.Xs;
		public static float DebrisForceY { get; private set; } = Config.SetForceY;
		public static float DebrisForceZ { get; private set; } = Config.SetForceZ;
		public static float DebrisMaxLifetime { get; private set; } = Config.SetLifetime;

		public static bool NCMenabled { get; private set; } = Config.SetNCMenabled;
		public static float NcmForceMultiplier { get; private set; } = Config.SetNcmForceMultiplier;
		public static float NcmDebrisLifetime { get; private set; } = Config.SetNcmDebrisLifetime;

		public static bool DebuggingEnabled { get; private set; } = Config.SetDebuggingEnabled;
		public static int DebugLogCapacity { get; private set; } = Config.SetDebrisLogCapacity;

		[Init]
		public void Init(IPALogger logger)
		{
			Config.Init();
			Logger.log = logger;
		}

		private void LoadConfig()
		{
			// Main settings
			ModEnabled = Config.MODENABLED;
			DebrisForceX = Config.Xs;
			DebrisForceY = Config.SetForceY;
			DebrisForceZ = Config.SetForceZ;
			DebrisMaxLifetime = Config.SetLifetime;

			// NoteCutMinimizer settings
			NCMenabled = Config.SetNCMenabled;
			NcmForceMultiplier = Config.SetNcmForceMultiplier;
			NcmDebrisLifetime = Config.SetNcmDebrisLifetime;

			// Other settings/debugging
			DebuggingEnabled = Config.SetDebuggingEnabled;
			DebugLogCapacity = Config.SetDebrisLogCapacity;

			Logger.log.Info("Config Loaded");

		}

		[OnStart]
		public void OnApplicationStart()
		{
			Logger.log.Info("Starting...");
			LoadConfig();
			BS_Utils.Utilities.BSEvents.gameSceneLoaded += LoadConfig;
			LoadHarmonyPatches();

		}

		[OnExit]
		public void OnApplicationExit()
		{
			UnloadHarmonyPatches();
			Logger.log.Info("Exiting...");
		}

		internal void LoadHarmonyPatches()
		{
			if (harmonyPatchesLoaded)
			{
				//Logger.Log.Info("Harmony patches already loaded. Skipping...");
				return;
			}
			try
			{
				harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
				Logger.log.Info("Harmony patches loaded");
			}
			catch (Exception e)
			{
				Logger.log.Error("Harmony failed to load");
				Logger.log.Error(e.ToString());
			}
			harmonyPatchesLoaded = true;
		}

		internal void UnloadHarmonyPatches()
		{
			if (!harmonyPatchesLoaded)
			{
				return;
			}
			try
			{
				harmonyInstance.UnpatchAll(HARMONYID);
				Logger.log.Info("Harmony patches unloaded");
			}
			catch (Exception e)
			{
				Logger.log.Error("Harmony failed to unload");
				Logger.log.Error(e.ToString());
			}
			harmonyPatchesLoaded = false;
		}
	}
}

//public void OnFixedUpdate()
//      {

//      }

//      public void OnUpdate()
//      {

//      }

//      public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
//      {

//      }

//public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
//{
//    // Initialize CustomUI settings
//    if (scene.name == "MenuCore")
//    {
//        Settings.Load();
//        UI.BasicUI.CreateGameplayOptionsUI();
//    }

//    // Check for scene MenuCore and GameCore, MenuCore for initializing on start, GameCore for changes to config
//    if (scene.name == "MenuCore" || scene.name == "GameCore")
//    {
//        if (!harmonyPatchesLoaded && Settings._isModEnabled)
//        {
//            Logger.Log.Info("Loading Harmony patches...");
//            LoadHarmonyPatches();
//        }
//        if (harmonyPatchesLoaded && !Settings._isModEnabled)
//        {
//            Logger.Log.Info("Unloading Harmony patches...");
//            UnloadHarmonyPatches();
//        }
//    }

//}


//internal void LoadHarmonyPatches()
//{
//    if (harmonyPatchesLoaded)
//    {
//        Logger.Log.Info("Harmony patches already loaded. Skipping...");
//        return;
//    }
//    try
//    {
//        harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
//        Logger.Log.Info("Loaded Harmony patches.");
//    }
//    catch (Exception e)
//    {
//        Logger.Log.Error("Loading Harmony patches failed. Please check if you have Harmony installed.");
//        Logger.Log.Error(e.ToString());
//    }
//    harmonyPatchesLoaded = true;
//}

//internal void UnloadHarmonyPatches()
//{
//    if (!harmonyPatchesLoaded)
//    {
//        Logger.Log.Info("Harmony patches not loaded. Skipping...");
//        return;
//    }
//    try
//    {
//        harmonyInstance.UnpatchAll("com.yoeyyutch.BeatSaber.NoteDebrisRedux");
//        Logger.Log.Info("Unloaded Harmony patches.");
//    }
//    catch (Exception e)
//    {
//        Logger.Log.Error("Unloading Harmony patches failed.");
//        Logger.Log.Error(e.ToString());
//    }
//    harmonyPatchesLoaded = false;
//}
