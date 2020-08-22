//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace NoteDebrisRedux
{
	static public class Config
	{
		static BS_Utils.Utilities.Config config;


		static readonly string NoteDebrisSettings = "NoteDebrisSettings";




		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(Plugin.PluginName);
		}

		internal static bool ModEnabled
		{
			get
			{
				return config.GetBool(NoteDebrisSettings, "ModifyNoteDebris", true, true);
			}
			set
			{
				config.SetBool(NoteDebrisSettings, "ModifyNoteDebris", value);
			}
		}
		internal static float DebrisForceXY
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "ForceMultiplierX", 3.0f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "ForceMultiplierX", value);
			}
		}
		internal static float DebrisReductionFactor
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "ForceMultiplierY", .25f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "ForceMultiplierY", value);
			}
		}
		internal static float DebrisForceZ
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "ForceMultiplierZ", -2.0f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "ForceMultiplierZ", value);
			}
		}
		internal static float MaxLifetime
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "MaxDebrisLifetime", 1f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "MaxDebrisLIfetime", value);
			}
		}
		internal static float LifeTimePercentOfNoteInterval
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "lifeTimePercentOfNoteInterval", 1f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "lifeTimePercentOfNoteInterval", value);
			}
		}

		internal static float Eyelevel
		{
			get
			{
				return config.GetFloat(NoteDebrisSettings, "EyeLevel", 1.4f, true);
			}
			set
			{
				config.SetFloat(NoteDebrisSettings, "Eyelevel", value);
			}
		}
	}
}


//static readonly string rightSaberSettings = "RightSaberSettings";

//internal static bool MODR
//{
//	get
//	{
//		return config.GetBool(rightSaberSettings, "ModEnabled", true, true);
//	}
//	set
//	{
//		config.SetBool(rightSaberSettings, "ModEnabled", value);
//	}
//}
//internal static float XR
//{
//	get
//	{
//		return config.GetFloat(rightSaberSettings, "ForceMultiplierX", 2.0f, true);
//	}

//	set
//	{
//		config.SetFloat(rightSaberSettings, "ForceMultiplierX", value);
//	}
//}
//internal static float YR
//{
//	get
//	{
//		return config.GetFloat(rightSaberSettings, "ForceMultiplierY", 2.0f, true);
//	}
//	set
//	{

//		config.SetFloat(rightSaberSettings, "ForceMultiplierY", value);
//	}
//}
//internal static float ZR
//{
//	get
//	{
//		return config.GetFloat(rightSaberSettings, "ForceMultiplierZ",2.0f, true);
//	}
//	set
//	{

//		config.SetFloat(rightSaberSettings, "ForceMultiplierZ", value);
//	}
//}
//internal static float LIFER
//{
//	get
//	{
//		return config.GetFloat(rightSaberSettings, "DebrisMaxLifetime", 1f, true);
//	}
//	set
//	{
//		config.SetFloat(rightSaberSettings, "DebrisMaxLifetime", value);
//	}
//}





//internal static bool COPYLTOR
//{
//	get
//	{
//		return config.GetBool(modSettings, "UseLeftSettingsForBothSabers", false, true);
//	}

//	set
//	{
//		config.SetBool(modSettings, "UseLeftSettingsForBothSabers", value);
//	}
//}
//_____________________________________________________
//static readonly string sectionNCM = "NoteCutMinimizerSettings";
//static readonly string _info = "DebugSettings";

//#region NCMsettings

//static readonly string settingNCMenabled = "UseNoteCutMinimizerSettings";
//internal static bool SetNCMenabled
//{
//	get
//	{
//		return config.GetBool(sectionNCM, settingNCMenabled, false, true);
//	}
//	set
//	{
//		config.SetBool(sectionNCM, settingNCMenabled, value);
//	}
//}

//static readonly string settingNCMforce = "ncmForceMultipler";
//internal static float SetNcmForceMultiplier
//{
//	get
//	{
//		return config.GetFloat(sectionNCM, settingNCMforce, 2f, true);
//	}
//	set
//	{
//		config.SetFloat(sectionNCM, settingNCMforce, value);
//	}
//}

//static readonly string settingNcmDebrisLifetime = "ncmDebrisLifetime";
//internal static float SetNcmDebrisLifetime
//{
//	get
//	{
//		return config.GetFloat(sectionNCM, settingNcmDebrisLifetime, 1f, true);
//	}
//	set
//	{
//		config.SetFloat(sectionNCM, settingNcmDebrisLifetime, value);
//	}
//}

//#endregion


//static readonly string DEBUGGINGENABLED = "EnableDebugging";
//internal static bool SetDebuggingEnabled
//{
//	get
//	{
//		return config.GetBool(_info, DEBUGGINGENABLED, false, true);
//	}
//	set
//	{
//		config.GetBool(_info, DEBUGGINGENABLED, value);

//	}
//}

//internal static int Info_LogCapacity
//{
//	get => config.GetInt(_info, "LogCapacity", defaultValue: 100, autoSave: false);
//	set => config.SetInt(_info, "LogCapacity", value);
//}

//private static void LoadConfig()
//		{

//		}

//static readonly string setting = " ";
//internal static float var
//{

//	get
//	{
//		return config.GetFloat(sectionOne, setting, 1f, true);
//	}
//	set
//	{
//		config.SetFloat(sectionOne, setting, value);
//	}
//}
