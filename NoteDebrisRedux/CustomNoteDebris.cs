//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using UnityEngine;

namespace NoteDebrisRedux
{
	static public class CustomNoteDebris
	{
		internal static bool _modifyDebris { get; set; } = true;
		
		internal static Vector3 ForceMultiplier { get; set; } = Vector3.one;
		
		internal static float LifeTimeMax { get; set; } = 1.5f;
		internal static float LifeTimePercentOfNoteInterval;

		internal static void Load()
		{
			_modifyDebris = Config._enableMod;

			ForceMultiplier = new Vector3(Config._forceX, Config._forceY, Config._forceZ);
			LifeTimeMax = Config._lifeMax;
			LifeTimePercentOfNoteInterval = Config._lifeTimePercentOfNoteInterval;
			Logger.log.Info("NoteDebrisMods loaded");
		}
	}
}
//internal static float RightLifeMax { get; set; } = 1.5f;
//internal static Vector3 RightForce { get; set; } = Vector3.one;
//private static bool RightEnabled { get; set; } = false;
//gameInfo = null;
//gameInfo = new Info();

//RightForce = RightEnabled ? new Vector3(Config.XR, Config.YR, Config.ZR) : Vector3.one;
//RightLifeMax = RightEnabled ? Config.LIFER : 1.5f;

//NoteSpeed = gameInfo.NoteJumpSpeed;
//internal static void CopyLeftDebrisSettings()
//{
//	if (!Config.COPYLTOR)
//		return;
//	else
//	{
//		Config.XR = Config._forceX;
//		Config.YR = Config._forceY;
//		Config.ZR = Config._forceZ;
//		Config.LIFER = Config._lifeMax;
//	}
//}
