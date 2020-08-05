
using IPALogger = IPA.Logging.Logger;
using UnityEngine;

namespace NoteDebrisRedux
{
    internal static class Logger
    {
        public static IPALogger log { get; set; }

		public static void LogDebrisData(string msg, NoteData noteData,  Vector3 debrisforce, float lifeTime)
		{


			string noteID = noteData.id.ToString();
			int lane = noteData.lineIndex;
			int level = (int)noteData.noteLineLayer;
			string pos = "(" + lane + ", " + level + ")";
			string direction = noteData.cutDirection.ToString();
			string force = debrisforce.ToString("F3");
			string life = lifeTime.ToString("0.000");
			log.Info(string.Join(", ",msg, noteID, force, life, pos, direction));
		}
    }
}