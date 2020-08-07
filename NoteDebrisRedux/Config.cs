using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDebrisRedux
{
	static public class Config
	{
		static BS_Utils.Utilities.Config config;
		private static string s_publicVariable;
		static readonly string sectionNCM = "NoteCutMinimizerSettings";
		static readonly string section_Main = "Settings";
		static readonly string section_DebrisForceMultipliers = "DebrisForceMultipliers";
		static readonly string section_DebugSettings = "DebugSettings";


		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(Plugin.PluginName);
		}

		static public float PublicVar
		{
			get
			{
				return SetLifetime;
			}
		}

		static public float Debris_ForceMultiplier
		{
			get
			{
				return 1f;
			}
		}


		#region MainSettings

		static public bool MODENABLED
		{
			get
			{
				return config.GetBool(section_Main, "ModEnabled", true, true);
			}
		}

		static public float LIFETIME
		{
			get
			{
				return config.GetFloat(section_Main, "DebrisLifetime", 2.0f, true);
			}
		}

		#endregion

		static public float XFORCE
		{
			get
			{
				return config.GetFloat(section_DebrisForceMultipliers, "X", 2.0f, true);
			}
		}
		static public float YFORCE
		{
			get
			{
				return config.GetFloat(section_DebrisForceMultipliers, "Y", 2.0f, true);
			}
		}
		static public float ZFORCE
		{
			get
			{
				return config.GetFloat(section_DebrisForceMultipliers, "Z", 2.0f, true);
			}
		}

		static readonly string settingForceY = "ForceMultiplierY";
		internal static float SetForceY
		{
			get
			{
				return config.GetFloat(section_Main, settingForceY, 2.0f, true);
			}
			set
			{
				config.SetFloat(section_Main, settingForceZ, value);
			}
		}

		static readonly string settingForceZ = "ForceMultiplierZ";
		internal static float SetForceZ
		{
			get
			{
				return config.GetFloat(section_Main, settingForceZ, -2.0f, true);
			}
			set
			{
				config.SetFloat(section_Main, settingForceZ, value);
			}
		}

		static readonly string settingLifetime = "DebrisMaxLifetime";
		internal static float SetLifetime
		{
			get
			{
				return config.GetFloat(section_Main, settingLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(section_Main, settingLifetime, value);
			}
		}


		#region NCMsettings

		static readonly string settingNCMenabled = "UseNoteCutMinimizerSettings";
		internal static bool SetNCMenabled
		{
			get
			{
				return config.GetBool(sectionNCM, settingNCMenabled, false, true);
			}
			set
			{
				config.SetBool(sectionNCM, settingNCMenabled, value);
			}
		}

		static readonly string settingNCMforce = "ncmForceMultipler";
		internal static float SetNcmForceMultiplier
		{
			get
			{
				return config.GetFloat(sectionNCM, settingNCMforce, 2f, true);
			}
			set
			{
				config.SetFloat(sectionNCM, settingNCMforce, value);
			}
		}

		static readonly string settingNcmDebrisLifetime = "ncmDebrisLifetime";
		internal static float SetNcmDebrisLifetime
		{
			get
			{
				return config.GetFloat(sectionNCM, settingNcmDebrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionNCM, settingNcmDebrisLifetime, value);
			}
		}

		#endregion


		static readonly string DEBUGGINGENABLED = "EnableDebugging";
		internal static bool SetDebuggingEnabled
		{
			get
			{
				return config.GetBool(section_DebugSettings, DEBUGGINGENABLED, false, true);
			}
			set
			{
				config.GetBool(section_DebugSettings, DEBUGGINGENABLED, value);

			}
		}

		static readonly string settingDebrisLogCapacity = "DebugLogCapacity";
		internal static int SetDebrisLogCapacity
		{

			get
			{
				return config.GetInt(section_DebugSettings, settingDebrisLogCapacity, 100, true);
			}
			set
			{
				config.GetInt(section_DebugSettings, settingDebrisLogCapacity, value);
			}
		}

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
	}
}
