using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			string currentLevelString = Application.loadedLevelName;
			int currentLevel = int.Parse(currentLevelString);
			int nextLevel = currentLevel+1;
			string nextLevelString = nextLevel.ToString();
			Application.LoadLevel(nextLevelString);
		}
	}
}
