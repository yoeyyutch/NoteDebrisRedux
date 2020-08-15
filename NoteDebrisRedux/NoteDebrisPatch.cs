﻿
using HarmonyLib;
using UnityEngine;


namespace NoteDebrisRedux

{
	[HarmonyPatch(typeof(NoteDebris), "Init")]
	//[HarmonyPatch("Init")]
	class NoteDebrisPatch
	{
		public static void Prefix(NoteType noteType, Transform initTransform, Vector3 cutPoint, Vector3 cutNormal, ref Vector3 force, ref float lifeTime)
		{
			//float cutDistanceToCenter = Mathf.Abs(Vector3.Distance(initTransform.position, cutPoint));

			NoteData noteData = initTransform.parent.GetComponent<NoteController>().noteData;
			float nextNoteTime = noteData.timeToNextBasicNote;
			//float prevNoteTime = noteData.timeToPrevBasicNote;
			Vector3 initForce = new Vector3(force.x,force.y,Mathf.Abs(force.z));
			float initLifeTime = lifeTime;
			//float p = lifeTime / 1.5f;
			

			if (noteType == NoteType.NoteA)
			{
				force = Vector3.Scale(initForce, CustomNoteDebris.LeftForce);
				//force = Vector3.Scale(initForce, Plugin.LeftForce);
				lifeTime = Mathf.Clamp(nextNoteTime,0.1f, CustomNoteDebris.LeftLifeMax);
			}

			else if (noteType == NoteType.NoteB)
			{
				//force = Vector3.Scale(initForce, Plugin.RightForce);
				force = Vector3.Scale(initForce, CustomNoteDebris.RightForce);
				lifeTime = Mathf.Clamp(nextNoteTime, 0.1f, CustomNoteDebris.RightLifeMax);

			}


			else
			{
				lifeTime = initLifeTime;
				force = initForce;
			}

			if (noteData.id < 10)
			{
				Logger.LogDebrisData(noteData, initForce, initLifeTime, cutNormal);
				Logger.LogDebrisData(noteData, force, lifeTime, cutNormal);
			}
		}
	}
}

//			if(!Plugin.LeftEnabled && !Plugin.RightEnabled)
//			{
//				return;
//			}

//			else
//			{

//			}

//			if (!Plugin. && !Plugin.DebuggingEnabled) return;

//			else
//			{
//				var note = initTransform.parent.GetComponent<NoteController>();


//				if (Plugin.DebuggingEnabled && note.noteData.id < Plugin.DebugLogCapacity)
//				{
//					Logger.DebugSwing(note, cutPoint, cutNormal, force);
//					//Vector3 forceIn = force;
//					//float lifeTimeIn = lifeTime;
//					//Logger.LogDebrisData("I:", note.noteData, forceIn, lifeTimeIn);
//					//Logger.LogDebrisData("O:", note.noteData, force, lifeTime);
//				}




//				{
//					float life = Plugin.DebrisMaxLifetime;
//					life = Mathf.Abs((int)note.noteData.noteLineLayer - 1) > 0 ? life : life * 0.5f;
//					life = Mathf.Abs((float)note.noteData.lineIndex - 1.5f) > 1f ? life : life * 0.5f;

//					float fx = Mathf.Abs(force.x) > Mathf.Abs(force.y) ? force.x * Plugin.DebrisForceX : force.x;
//					float fy = Mathf.Abs(force.y) > Mathf.Abs(force.x) ? force.y * Plugin.DebrisForceY : force.y;
//					float fz = force.z * ((float)note.noteData.noteLineLayer + 0.5f) * Plugin.DebrisForceZ;

//					Vector3 newForce = new Vector3(fx, fy, fz);

//					//Vector3 newForce = new Vector3(Plugin.VelocityMultiplierX * force.x, Plugin.VelocityMultiplierY * force.y, Plugin.VelocityMultiplierZ * force.z);

//					lifeTime = life;
//					force = newForce;
//				}

//				else
//				{


//					if (note.noteData.id < Plugin.DebugLogCapacity)
//					{

//					}


//				}

//			}

//		}

//		public Vector3 ModifyDebrisForce(NoteType noteType, Vector3 force)
//		{
//			Vector3 v = new Vector3
//			return
//		}

//	}



//}
//if (Plugin.NCMenabled)
//{

//	lifeTime = lifeTime - Mathf.Clamp(initTransform.position.y - 1f, 0f, 0.5f);

//	float minForce = 2f;
//	float maxForce = 8f;

//	float forceMultiplier = Plugin.NcmForceMultiplier;

//	minForce *= forceMultiplier;
//	maxForce *= forceMultiplier;


//	force.y = Random.Range(-2f * forceMultiplier, -0.15f * forceMultiplier);

//	if (note)
//	{

//		switch (note.noteData.cutDirection)
//		{
//			case NoteCutDirection.Left:
//				force.x = Random.Range(-maxForce, -minForce);
//				break;

//			case NoteCutDirection.Right:
//				force.x = Random.Range(minForce, maxForce);
//				break;

//			case NoteCutDirection.DownLeft:
//			case NoteCutDirection.UpLeft:
//				force.x = Random.Range(-maxForce / 2, -minForce / 2);
//				break;

//			case NoteCutDirection.DownRight:
//			case NoteCutDirection.UpRight:
//				force.x = Random.Range(minForce / 2, maxForce / 2);
//				break;
//		}
//	}

//}



//float cm = Mathf.Abs(Vector3.Magnitude(initTransform.InverseTransformPoint(cutPoint)));
//float diagonalForceMultiplier = 0.707f;

//float minForce = 2f;
//float maxForce = 8f;

//float forceMultiplier = 3f;

//minForce *= forceMultiplier;
//maxForce *= forceMultiplier;


//force.y = Random.Range(-2f * forceMultiplier, -0.15f * forceMultiplier);


//var note = initTransform.parent.GetComponent<NoteController>();

//if (note)
//{
//	// a^2 + a^2 = 1
//	switch (note.noteData.cutDirection)
//	{
//		case NoteCutDirection.Left:
//			force.x = Random.Range(-maxForce, -minForce);
//			break;

//		case NoteCutDirection.Right:
//			force.x = Random.Range(minForce, maxForce);
//			break;

//		case NoteCutDirection.DownLeft:
//		case NoteCutDirection.UpLeft:
//			force.x = Random.Range(-maxForce / 2, -minForce / 2);
//			break;

//		case NoteCutDirection.DownRight:
//		case NoteCutDirection.UpRight:
//			force.x = Random.Range(minForce / 2, maxForce / 2);
//			break;
//	}
//}

//lifeTime = lifeTime - Mathf.Clamp(initTransform.position.y - 1f, 0f, 0.5f);

