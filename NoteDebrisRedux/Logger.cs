
using IPALogger = IPA.Logging.Logger;
using UnityEngine;

namespace NoteDebrisRedux
{
    internal static class Logger
    {
        public static IPALogger log { get; set; }

		public static void LogDebrisData(NoteData noteData, Vector3 debrisforce, float lifeTime, Vector3 cutNormal)
		{

			string noteID = "ID: " + noteData.id.ToString();
			string nextNoteTime = "T: " + noteData.timeToNextBasicNote;
			//int lane = noteData.lineIndex;
			//int level = (int)noteData.noteLineLayer;
			//string pos = "(" + lane + ", " + level + ")";
			string direction = noteData.cutDirection.ToString();
			string force = "D: " + debrisforce.ToString("F3");
			string life = "L: " + lifeTime.ToString("0.000");
			string normal = "N: " + cutNormal.ToString("F2");
			log.Info(string.Join(", ", noteID, force, normal, direction, life, nextNoteTime));
		}

		public static void DebugSwing(NoteController note, Vector3 cutPoint, Vector3 cutNormal, Vector3 debrisForce)
		{
			int id = note.noteData.id;
			string direction = note.noteData.cutDirection.ToString();
			string normal = cutNormal.ToString("F2");
			string force = debrisForce.ToString("F3");
		}
	}
}