using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;

	public Texture2D bgImage;
	public Texture2D fgImage;



	public float healthBarLength;

	void Start(){
		healthBarLength = Screen.width / 2;
	}

	void Update(){
		AddjustCurrentHealth ();
	}

	void OnGUI(){
		GUIStyle style = new GUIStyle ("box");
		style.padding = new RectOffset (0, 0, 0, 0);
		style.fixedHeight = 0;
		style.fixedWidth = 0;
		style.stretchHeight = true;
		style.stretchWidth = true;

		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup(new Rect(0,0, Screen.width / 2, 32));

			// Draw the background image
		GUI.Box (new Rect (0, 0, Screen.width / 2, 32), bgImage);
//		GUI.color = Color.red;
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, Screen.width / 2, 32));

		// Draw the foreground image
		GUI.Box (new Rect (0,0,healthBarLength,32), fgImage, style);


		// End both Groups
		GUI.EndGroup ();
		
		GUI.EndGroup ();
		             
	}

	public void AddjustCurrentHealth(){

		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	// Function is called from enemy when attacked
	public void ApplyDamage(int dmg){
		curHealth -= dmg;
		if (curHealth <= 0) {
			playerDied();
		}
	}

	private void playerDied(){
		Application.LoadLevel ("MainMenu");

	}
}
	

