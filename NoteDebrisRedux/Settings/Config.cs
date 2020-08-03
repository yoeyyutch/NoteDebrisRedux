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
		static readonly string sectionOne = "NoteCutMinimizerSettings";
		static readonly string sectionTwo = "NoteDebrisReduxSettings";
		static readonly string sectionThree = "DebugSettings";

		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(configName);
		}

		//static readonly string modEnabled = "EnableMod";
		//internal static bool ModEnabled
		//{
		//	get
		//	{
		//		return config.GetBool(section, modEnabled, true, false);
		//	}
		//	set
		//	{
		//		config.SetBool(section, modEnabled, value);
		//	}
		//}

		static readonly string useNcmMode = "UseNoteCutMinimizerSettings";
		internal static bool UsingNCM
		{
			get
			{
				return config.GetBool(sectionOne, useNcmMode, false, true);
			}
			set
			{
				config.SetBool(sectionOne, useNcmMode, value);
			}
		}

		static readonly string ncmForceMultiplier = "ncmForceMultipler";
		internal static float NcmForceMultiplier
		{
			get
			{
				return config.GetFloat(sectionOne, ncmForceMultiplier, 2f, true);
			}
			set
			{
				config.SetFloat(sectionOne, ncmForceMultiplier, value);
			}
		}

		static readonly string ncmDebrisLifetime = "ncmDebrisLifetime";
		internal static float NcmDebrisLifetime
		{
			get
			{
				return config.GetFloat(sectionOne, ncmDebrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionOne, ncmDebrisLifetime, value);
			}
		}


		static readonly string velocityMultiplierX = "VelocityMultiplierX";
		internal static float VelocityMultiplierX
		{
			get
			{
				return config.GetFloat(sectionOne, velocityMultiplierX, 2.0f, true);
			}
			set
			{
				config.SetFloat(sectionOne, velocityMultiplierX, value);
			}
		}

		static readonly string velocityMultiplierY = "VelocityMultiplierY";
		internal static float VelocityMultiplierY
		{
			get
			{
				return config.GetFloat(sectionOne, velocityMultiplierY, 2.0f, true);
			}
			set
			{
				config.SetFloat(sectionOne, velocityMultiplierZ, value);
			}
		}

		static readonly string velocityMultiplierZ = "VelocityMultiplierZ";
		internal static float VelocityMultiplierZ
		{
			get
			{
				return config.GetFloat(sectionOne, velocityMultiplierZ, 2.0f, true);
			}
			set
			{
				config.SetFloat(sectionOne, velocityMultiplierZ, value);
			}
		}

		static readonly string debrisLifetime = "DebrisLifetime";
		internal static float DebrisLifetime
		{
			get
			{
				return config.GetFloat(sectionOne, debrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionOne, debrisLifetime, value);
			}
		}

		static readonly string noteLogCapacity = "NoteLogCapacity";
		internal static float NoteLogCapacity
		{

			get
			{
				return config.GetFloat(sectionThree, noteLogCapacity, 1f, true);
			}
			set
			{
				config.SetFloat(sectionThree, noteLogCapacity, value);
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
