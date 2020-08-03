
using HarmonyLib;
using UnityEngine;


namespace NoteDebrisRedux

{
	[HarmonyPatch(typeof(NoteDebris))]
	[HarmonyPatch("Init")]
	class NoteDebrisPatch
	{
		public static void Prefix(ref Transform initTransform, ref Vector3 cutPoint, ref Vector3 force, ref float lifeTime)
		{
			if (Plugin.UsingNCM)
			{

				lifeTime = lifeTime - Mathf.Clamp(initTransform.position.y - 1f, 0f, 0.5f);

				float minForce = 2f;
				float maxForce = 8f;

				float forceMultiplier = Plugin.NcmForceMultiplier;

				minForce *= forceMultiplier;
				maxForce *= forceMultiplier;


				force.y = Random.Range(-2f * forceMultiplier, -0.15f * forceMultiplier);


				var note = initTransform.parent.GetComponent<NoteController>();

				if (note)
				{

					switch (note.noteData.cutDirection)
					{
						case NoteCutDirection.Left:
							force.x = Random.Range(-maxForce, -minForce);
							break;

						case NoteCutDirection.Right:
							force.x = Random.Range(minForce, maxForce);
							break;

						case NoteCutDirection.DownLeft:
						case NoteCutDirection.UpLeft:
							force.x = Random.Range(-maxForce / 2, -minForce / 2);
							break;

						case NoteCutDirection.DownRight:
						case NoteCutDirection.UpRight:
							force.x = Random.Range(minForce / 2, maxForce / 2);
							break;
					}
				}

			}

			else
			{

				float fx = Mathf.Abs(force.x) > Mathf.Abs(force.y) ? force.x * Plugin.VelocityMultiplierX : 1f;
				float fy = Mathf.Abs(force.y) > Mathf.Abs(force.x) ? force.y * Plugin.VelocityMultiplierY : 1f;
				float fz = force.z * Plugin.VelocityMultiplierZ;

				Vector3 newForce = new Vector3(fx, fy, fz);

				//Vector3 newForce = new Vector3(Plugin.VelocityMultiplierX * force.x, Plugin.VelocityMultiplierY * force.y, Plugin.VelocityMultiplierZ * force.z);

				force = newForce;

				lifeTime = Plugin.DebrisLifetime;
			}


		}

	}



}


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

