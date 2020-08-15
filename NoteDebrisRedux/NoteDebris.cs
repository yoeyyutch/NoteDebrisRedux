using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoteDebrisRedux
{
	class NoteDebris
	{
		private static bool LeftEnabled { get; set; } = false;
		private static bool RightEnabled { get; set; } = false;
		internal static Vector3 LeftForce { get; set; } = Vector3.one;
		internal static Vector3 RightForce { get; set; } = Vector3.one;
		internal static float LeftLifeMax { get; set; } = 1.5f;
		internal static float RightLifeMax { get; set; } = 1.5f;

		internal static void LoadDebrisMods()
		{
			//gameInfo = null;
			//gameInfo = new Info();


			//NoteSpeed = gameInfo.NoteJumpSpeed;
			LeftEnabled = Config.MODL;
			RightEnabled = Config.MODR;
			Config.CopyLeftDebrisSettings();


			LeftForce = LeftEnabled ? new Vector3(Config.XL, Config.YL, Mathf.Abs(Config.ZL)) : Vector3.one;
			RightForce = RightEnabled ? new Vector3(Config.XR, Config.YR, Mathf.Abs(Config.ZR)) : Vector3.one;
			LeftLifeMax = LeftEnabled ? Config.LIFEL : 1.5f;
			RightLifeMax = RightEnabled ? Config.LIFER : 1.5f;

		}
	}
}
