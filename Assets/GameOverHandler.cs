using UnityEngine;
using System.Collections;

public class GameOverHandler : MonoBehaviour {

	public void ChangeLevel(){
		Application.LoadLevel (0);
	}

	public void NextLevel(){
		int currentLevel = Application.loadedLevel;
		int nextLevel = currentLevel+1;
		Application.LoadLevel(nextLevel);
	}

	public void upgradeHP(){
		int hp = playerHealth.maxHealth;
		hp += 10;
		playerHealth.maxHealth = hp;
	}
}
