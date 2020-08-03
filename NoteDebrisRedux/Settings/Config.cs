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
		static readonly string section = "Settings";

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
				return config.GetBool(section, useNcmMode, false, true);
			}
			set
			{
				config.SetBool(section, useNcmMode, value);
			}
		}

		static readonly string ncmForceMultiplier = "ncmForceMultipler";
		internal static float NcmForceMultiplier
		{
			get
			{
				return config.GetFloat(section, ncmForceMultiplier, 2f, true);
			}
			set
			{
				config.SetFloat(section, ncmForceMultiplier, value);
			}
		}

		static readonly string ncmDebrisLifetime = "ncmDebrisLifetime";
		internal static float NcmDebrisLifetime
		{
			get
			{
				return config.GetFloat(section, ncmDebrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(section, ncmDebrisLifetime, value);
			}
		}


		static readonly string velocityMultiplierX = "VelocityMultiplierX";

		internal static float VelocityMultiplierX
		{
			get
			{
				return config.GetFloat(section, velocityMultiplierX, 2.0f, true);
			}
			set
			{
				config.SetFloat(section, velocityMultiplierX, value);
			}
		}

		static readonly string velocityMultiplierY = "VelocityMultiplierY";
		internal static float VelocityMultiplierY
		{
			get
			{
				return config.GetFloat(section, velocityMultiplierY, 2.0f, true);
			}
			set
			{
				config.SetFloat(section, velocityMultiplierZ, value);
			}
		}

		static readonly string velocityMultiplierZ = "VelocityMultiplierZ";
		internal static float VelocityMultiplierZ
		{
			get
			{
				return config.GetFloat(section, velocityMultiplierZ, 2.0f, true);
			}
			set
			{
				config.SetFloat(section, velocityMultiplierZ, value);
			}
		}

		static readonly string debrisLifetime = "DebrisLifetime";
		internal static float DebrisLifetime
		{
			get
			{
				return config.GetFloat(section, debrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(section, debrisLifetime, value);
			}
		}
	}
}
