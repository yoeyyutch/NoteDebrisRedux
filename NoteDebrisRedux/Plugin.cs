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
		public static string Version => "1.4.1";

		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.NoteDebrisRedux";
		internal static bool harmonyPatchesLoaded = false;
		internal static readonly Harmony harmonyInstance = new Harmony(HARMONYID);

		[Init]
		public void Init(IPALogger logger)
		{
			Config.Init();
			Logger.log = logger;
			CustomNoteDebris.Load();

		}

		[OnStart]
		public void OnApplicationStart()
		{
			Logger.log.Info("Starting...");
			UnloadEvents();
			LoadEvents();
			LoadHarmonyPatches();
		}

		[OnExit]
		public void OnApplicationExit()
		{
			UnloadEvents();
			UnloadHarmonyPatches();
		}

		public void OnGameSceneLoaded()
		{
			Logger.log.Info("OnGameSceneLoaded called.");
			CustomNoteDebris.Load();
		}

		internal void LoadEvents()
		{

			BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;

		}

		internal void UnloadEvents()
		{
			BS_Utils.Utilities.BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
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

//internal readonly string InfoDirectory = Path.Combine(UnityGame.UserDataPath, PluginName);

//private readonly GameplayCoreSceneSetupData _sceneData;
//public GameplayCoreSceneSetupData GetSceneData() => _sceneData;

//private Info gameInfo;


//public bool LeftEnabled { get; set; }
//public bool RightEnabled { get; set; }
//public static Vector3 LeftForce { get; set; }
//public static Vector3 RightForce { get; set; }
//public static float LeftLifeMax { get; set; }
//public static float RightLifeMax { get; set; }
//public static float NoteSpeed { get; set; }
//private void LoadConfig()

//{
//	//gameInfo = null;
//	//gameInfo = new Info();


//	//NoteSpeed = gameInfo.NoteJumpSpeed;
//	LeftEnabled = Config.MODL;
//	RightEnabled = Config.MODR;
//	Config.CopyLeftDebrisSettings();


//	LeftForce = LeftEnabled ? new Vector3(Config.XL, Config.YL, Mathf.Abs(Config.ZL)) : Vector3.one;
//	RightForce = RightEnabled ? new Vector3(Config.XR, Config.YR, Mathf.Abs(Config.ZR)) : Vector3.one;
//	LeftLifeMax = LeftEnabled ? Config.LIFEL : 1.5f;
//	RightLifeMax = RightEnabled ? Config.LIFER : 1.5f;

//}

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

//public static Vector3 DebrisForceMultiplier { get; private set; } = new Vector3(Config.VelocityMultiplierX, Config.VelocityMultiplierY, Config.VelocityMultiplierZ);


//public static bool ModEnabled { get; private set; } = Config.IsEnabled;
//public static float DebrisForceX { get; private set; } = Config.Xs;
//public static float DebrisForceY { get; private set; } = Config._YForce;
//public static float DebrisForceZ { get; private set; } = Config._ZForce;
//public static float DebrisMaxLifetime { get; private set; } = Config._MaxLifetime;

//public static bool NCMenabled { get; private set; } = Config.SetNCMenabled;
//public static float NcmForceMultiplier { get; private set; } = Config.SetNcmForceMultiplier;
//public static float NcmDebrisLifetime { get; private set; } = Config.SetNcmDebrisLifetime;

//public static bool DebuggingEnabled { get; private set; } = Config.SetDebuggingEnabled;
//public static int DebugLogCapacity { get; private set; } = Config.Info_LogCapacity;

//private void LoadConfig()
//{
//	// Main settings
//	ModEnabled = Config.IsEnabled;
//	DebrisForceX = Config.Xs;
//	DebrisForceY = Config._YForce;
//	DebrisForceZ = Config._ZForce;
//	DebrisMaxLifetime = Config._MaxLifetime;

//	// NoteCutMinimizer settings
//	NCMenabled = Config.SetNCMenabled;
//	NcmForceMultiplier = Config.SetNcmForceMultiplier;
//	NcmDebrisLifetime = Config.SetNcmDebrisLifetime;

//	// Other settings/debugging
//	DebuggingEnabled = Config.SetDebuggingEnabled;
//	DebugLogCapacity = Config.Info_LogCapacity;

//	Logger.log.Info("Config Loaded");

//}
