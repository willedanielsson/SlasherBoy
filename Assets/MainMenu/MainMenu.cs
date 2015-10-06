using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture backgroundTexture;

	void OnGUI(){
		// Display backgruiond texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		if (GUI.Button(new Rect(10, (Screen.height)/2, 100, 50), "Restart"))
			Application.LoadLevel("1");
	}
}
