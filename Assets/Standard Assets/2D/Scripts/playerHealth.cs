using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour {
	public Scrollbar healthBar;
	public int maxHealth = 100;
	public int curHealth = 100;

	public int level = 0;
	public int experience = 0;
	public int skillpoint = 0;


	void Start(){

	}

	void Update(){
		//AddjustCurrentHealth ();
	}

	void OnGUI(){
	
		// Styling for the experince text
		GUIStyle expStyle = new GUIStyle ();
		expStyle.normal.textColor = Color.yellow;
		expStyle.fontSize = 30;
		GUI.Label (new Rect (Screen.width / 2, 0, 100, 32), "Exp: "+experience, expStyle);

		             
	}
	
	// Function is called from enemy when attacked
	public void ApplyDamage(int dmg){
		curHealth -= dmg;
		healthBar.size = curHealth / 100f;
		if (curHealth <= 0) {
			playerDied();
		}
	}
	public void addExp(int exp){
		experience += exp;
	}


	private void playerDied(){
		Application.LoadLevel ("MainMenu");

	}
}
	

