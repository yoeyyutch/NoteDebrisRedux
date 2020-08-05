using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDebrisRedux.Settings
{
	static class Config
	{
		static BS_Utils.Utilities.Config config;

		static readonly string configName = "NoteDebrisRedux";
		static readonly string sectionNCM = "NoteCutMinimizerSettings";
		static readonly string sectionMain = "NoteDebrisReduxSettings";
		static readonly string sectionDebug = "DebugSettings";

		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(configName);
		}

		#region NCMsettings

		static readonly string useNcmMode = "UseNoteCutMinimizerSettings";
		internal static bool UsingNCM
		{
			get
			{
				return config.GetBool(sectionNCM, useNcmMode, false, true);
			}
			set
			{
				config.SetBool(sectionNCM, useNcmMode, value);
			}
		}

		static readonly string ncmForceMultiplier = "ncmForceMultipler";
		internal static float NcmForceMultiplier
		{
			get
			{
				return config.GetFloat(sectionNCM, ncmForceMultiplier, 2f, true);
			}
			set
			{
				config.SetFloat(sectionNCM, ncmForceMultiplier, value);
			}
		}

		static readonly string ncmDebrisLifetime = "ncmDebrisLifetime";
		internal static float NcmDebrisLifetime
		{
			get
			{
				return config.GetFloat(sectionNCM, ncmDebrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionNCM, ncmDebrisLifetime, value);
			}
		}

		#endregion

		#region MainSettings
		static readonly string velocityMultiplierX = "VelocityMultiplierX";
		internal static float VelocityMultiplierX
		{
			get
			{
				return config.GetFloat(sectionMain, velocityMultiplierX, 2.0f, true);
			}
			set
			{
				config.SetFloat(sectionMain, velocityMultiplierX, value);
			}
		}

		static readonly string velocityMultiplierY = "VelocityMultiplierY";
		internal static float VelocityMultiplierY
		{
			get
			{
				return config.GetFloat(sectionMain, velocityMultiplierY, 2.0f, true);
			}
			set
			{
				config.SetFloat(sectionMain, velocityMultiplierZ, value);
			}
		}

		static readonly string velocityMultiplierZ = "VelocityMultiplierZ";
		internal static float VelocityMultiplierZ
		{
			get
			{
				return config.GetFloat(sectionMain, velocityMultiplierZ, -2.0f, true);
			}
			set
			{
				config.SetFloat(sectionMain, velocityMultiplierZ, value);
			}
		}

		static readonly string debrisMaxLifetime = "DebrisMaxLifetime";
		internal static float DebrisMaxLifetime
		{
			get
			{
				return config.GetFloat(sectionMain, debrisMaxLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionMain, debrisMaxLifetime, value);
			}
		}
		#endregion


		static readonly string debrisLogCapacity = "NoteLogCapacity";
		internal static int DebrisLogCapacity
		{

			get
			{
				return config.GetInt(sectionDebug, debrisLogCapacity, 100, true);
			}
			set
			{
				config.GetInt(sectionDebug, debrisLogCapacity, value);
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
