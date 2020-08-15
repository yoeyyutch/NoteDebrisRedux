using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteDebrisRedux
{
	public class Info
	{
		private readonly GameplayCoreSceneSetupData _sceneData;
		public GameplayCoreSceneSetupData GetSceneData() => _sceneData;
		public float NoteJumpSpeed;

		public Info()
		{
			_sceneData = BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData;
			NoteJumpSpeed = _sceneData.difficultyBeatmap.noteJumpMovementSpeed;
		}
	}
}
