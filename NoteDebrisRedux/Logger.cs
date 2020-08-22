
using IPALogger = IPA.Logging.Logger;
using UnityEngine;

namespace NoteDebrisRedux
{
	internal static class Logger
	{
		public static IPALogger log { get; set; }

		public static void LogDebrisData(string msg, Transform note, Vector3 debrisforce, float lifeTime)
		{
			NoteData data = note.GetComponentInParent<NoteController>().noteData;
			string noteID = "ID: " + data.id.ToString();
			string force = "D: " + debrisforce.ToString("F2");
			string life = "L: " + lifeTime.ToString("0.0");
			string position = "P: " + CustomNoteDebris.NotePositionToView(note).ToString("F3");
			string angle = "A: " + CustomNoteDebris.DebrisAngleToView(note, debrisforce).ToString("0.0");
			//string nextNoteTime = "T: " + data.timeToNextBasicNote;
			//int lane = noteData.lineIndex;
			//int level = (int)noteData.noteLineLayer;
			//string pos = "(" + lane + ", " + level + ")";
			//string direction = data.cutDirection.ToString();
			//string normal = "N: " + cutNormal.ToString("F2");

			log.Info(string.Join(", ", msg, noteID, position, force, angle, life));
		}

		//public static void DebugSwing(NoteController note, Vector3 cutPoint, Vector3 cutNormal, Vector3 debrisForce)
		//{
		//	int id = note.noteData.id;
		//	string direction = note.noteData.cutDirection.ToString();
		//	string normal = cutNormal.ToString("F2");
		//	string force = debrisForce.ToString("F3");
		//}
	}
}