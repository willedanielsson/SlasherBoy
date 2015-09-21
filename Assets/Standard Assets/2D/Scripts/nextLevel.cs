using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "Player") {
			Application.LoadLevel("test");
		}
	}
}
