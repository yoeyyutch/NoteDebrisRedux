//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

namespace NoteDebrisRedux
{
	static public class CustomNoteDebris
	{
		internal static float Eyelevel = 1.4f;
		internal static bool ModifyDebris { get; set; } = true;
		internal static float ForceXY { get; set; } = 1f;
		internal static float ForceZ { get; set; } = 1f;

		//private static float DebrisReduction { get; set; } = .25f;
		internal static float LifeTimeMax { get; set; } = 1.5f;
		internal static float LifeTimePercentOfNoteInterval { get; set; } = .8f;

		internal static void Load()
		{
			ModifyDebris = Config.ModEnabled;
			Eyelevel = Config.Eyelevel;
			ForceXY = Config.DebrisForceXY;
			ForceZ = Config.DebrisForceZ;
			//DebrisReduction = Config.DebrisReductionFactor;
			LifeTimeMax = Config.MaxLifetime;
			LifeTimePercentOfNoteInterval = Config.LifeTimePercentOfNoteInterval;
			Logger.log.Info("NoteDebrisMods loaded");
		}
		static public bool DebrisObstructsView(float angle) => angle > 125f;

		public static Vector3 HeadPosition() => Resources.FindObjectsOfTypeAll<PlayerController>().First().headPos;

		//public static Vector3 NotePositionToView(Transform note) => new Vector2(note.position.x - HeadPosition().x, note.position.y - HeadPosition().y);

		//public static Vector3 ForceMultiplier(bool obstructsView) => obstructsView ? new Vector3(DebrisReduction, DebrisReduction, ForceZ) : new Vector3(ForceXY, ForceXY, ForceZ);

		public static Vector3 ForceAdjustment() => new Vector3(ForceXY, ForceXY, ForceZ);

		public static float LifetimeAdjustment(float angle, bool obstructsView, float timeBetweenNotes)
		{
			float t = timeBetweenNotes * LifeTimePercentOfNoteInterval;
			float result;
			if (angle < 60f)
			{
				result = LifeTimeMax;
			}
			else if (obstructsView)
			{
				result = Mathf.Min(t, 0.1f);
			}
			else
			{
				result = t;
			}

			return result;
		}

		//public static float DebrisAngleToView(Transform note, Vector3 debris)
		//{
		//	//Vector2 from = NotePositionToView(note);
		//	//Vector2 to = new Vector2(debris.x, debris.y);
		//	return Vector2.Angle(NotePositionToView(note), new Vector2(debris.x, debris.y));
		//}



	}
}


		//static public Vector2 ObstructionFactor(Transform noteTransform, NoteData noteData)
		//{
		//	Vector2 noteDirection = noteData.cutDirection.Direction();
		//	Vector2 notePosition = new Vector2(noteTransform.position.x, noteTransform.position.y - Eyelevel).normalized;
		//	float amount = noteDirection == Vector2.zero ? 90f : Vector2.Angle(notePosition, noteDirection);
		//	amount /= 90f;
		//	amount *= ObstructionMultiplier;
		//	Vector2 result = new Vector2(notePosition.x * amount, notePosition.y * amount);
		//	return result;
		//}

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
