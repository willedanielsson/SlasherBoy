using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			int currentLevel = Application.loadedLevel;
			int nextLevel = currentLevel+1;
			//print (nextLevelString);
			Application.LoadLevel(nextLevel);
		}
	}
}
