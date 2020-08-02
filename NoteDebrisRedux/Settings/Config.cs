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
		static readonly string sectionDebris = "Debris";

		internal static void Init()
		{
			config = new BS_Utils.Utilities.Config(configName);
		}

		static readonly string velocityMultiplierX = "VelocityMultiplierX";

		internal static float VelocityMultiplierX
		{
			get
			{
				return config.GetFloat(sectionDebris, velocityMultiplierX, 1.0f, true);
			}
			set
			{
				config.SetFloat(sectionDebris, velocityMultiplierX, value);
			}
		}

		static readonly string velocityMultiplierY = "VelocityMultiplierY";
		internal static float VelocityMultiplierY
		{
			get
			{
				return config.GetFloat(sectionDebris, velocityMultiplierY, 1.0f, true);
			}
			set
			{
				config.SetFloat(sectionDebris, velocityMultiplierZ, value);
			}
		}

		static readonly string velocityMultiplierZ = "VelocityMultiplierZ";
		internal static float VelocityMultiplierZ
		{
			get
			{
				return config.GetFloat(sectionDebris, velocityMultiplierZ, 1.0f, true);
			}
			set
			{
				config.SetFloat(sectionDebris, velocityMultiplierZ, value);
			}
		}

		static readonly string debrisLifetime = "DebrisLifetime";
		internal static float DebrisLifetime
		{
			get
			{
				return config.GetFloat(sectionDebris, debrisLifetime, 1f, true);
			}
			set
			{
				config.SetFloat(sectionDebris, debrisLifetime, value);
			}
		}
	}
}
