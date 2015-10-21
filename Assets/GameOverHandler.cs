using UnityEngine;
using System.Collections;

public class GameOverHandler : MonoBehaviour {
	public int experience = playerHealth.experience;

	public void ChangeLevel(){
		playerHealth.curHealth = playerHealth.maxHealth;
		Application.LoadLevel (0);
	}

	public void NextLevel(){
		int currentLevel = Application.loadedLevel;
		int nextLevel = currentLevel+1;
		Application.LoadLevel(nextLevel);
	}

	public void upgradeHP(){
		if (experience > 0) {
			experience--;
			int hp = playerHealth.maxHealth;
			hp += 10;
			playerHealth.maxHealth = hp;
		}
	}

	public void upgradeAttack(){
		if (experience > 0) {
			experience--;
			int attack = attackTrigger.dmg;
			attack += 2;
			attackTrigger.dmg = attack;
		}
	}

	void OnGUI(){
		
		// Styling for the experince text
		GUIStyle expStyle = new GUIStyle ();
		expStyle.normal.textColor = Color.yellow;
		expStyle.fontSize = 30;
		GUI.Label (new Rect (Screen.width / 2, 0, 100, 32), "Exp: "+experience, expStyle);
	}

}
