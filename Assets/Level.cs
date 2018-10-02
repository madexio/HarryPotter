using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[System.Serializable]
	public class Enterance {
		public int PreviousLevel;
		public Transform Position;
	}

	public List<Enterance> Enterances;
	public GameObject Player;

	public int LevelID;
	private static int LastLevelID = -1;

	[Header("Debug")]
	public bool OverwriteStartPoint = false;
	public int LastLevelOverride = -1;

	void Awake() {
		if (OverwriteStartPoint) {
			LastLevelID = LastLevelOverride;
		}
	}

	// Use this for initialization
	void Start () {
		foreach (Enterance enterance in Enterances) {
			if (enterance.PreviousLevel == LastLevelID) {
				Player.transform.position = enterance.Position.position;
			}
		}
	}

	private void OnDisable() {
		LastLevelID = LevelID;
	}
}
