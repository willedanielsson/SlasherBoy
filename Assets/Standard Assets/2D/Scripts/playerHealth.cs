using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	public int experience = 0;

	public Texture2D bgImage;
	public Texture2D fgImage;

	public float healthBarLength;

	void Start(){
		healthBarLength = Screen.width / 3;

	}

	void Update(){
		AddjustCurrentHealth ();
	}

	void OnGUI(){

		
		// Styling for the bar
		GUIStyle barStyle = new GUIStyle ();
		barStyle.padding = new RectOffset (0, 0, 0, 0);
		barStyle.fixedHeight = 0;
		barStyle.fixedWidth = 0;
		barStyle.stretchHeight = true;
		barStyle.stretchWidth = true;
		
		// Styling for the experince text
		GUIStyle expStyle = new GUIStyle ();
		expStyle.normal.textColor = Color.yellow;
		expStyle.fontSize = 30;

		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup(new Rect(0,0, Screen.width / 3, 32));

			// Draw the background image
		GUI.Box (new Rect (0, 0, Screen.width / 3, 32), bgImage);
//		GUI.color = Color.red;
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, Screen.width / 2, 32));

		// Draw the foreground image
		GUI.Box (new Rect (0,0,healthBarLength,32), fgImage, barStyle);


		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();

		GUI.Label (new Rect (Screen.width / 2, 0, 100, 32), "Exp: "+experience, expStyle);

		             
	}

	public void AddjustCurrentHealth(){

		healthBarLength = (Screen.width / 3) * (curHealth / (float)maxHealth);
	}

	// Function is called from enemy when attacked
	public void ApplyDamage(int dmg){
		curHealth -= dmg;
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
	

