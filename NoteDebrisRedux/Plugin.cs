using IPA.Utilities;
using IPA;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using HarmonyLib;

namespace NoteDebrisRedux
{

	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
    {
        internal static string PluginName => "NoteDebrisRedux";
        public const string Version = "0.0.0";
		internal const string HARMONYID = "com.yoeyyutch.BeatSaber.NoteDebrisRedux";

		internal static readonly Harmony HarmonyInstance = new Harmony(HARMONYID);

		[Init]
		public void Init(IPALogger logger)
		{
			Logger.Log = logger;
		}

		[OnStart]
		public void OnApplicationStart()
        {
			HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}
		[OnExit]
        public void OnApplicationExit()
        {
			HarmonyInstance.UnpatchAll(HARMONYID);
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
