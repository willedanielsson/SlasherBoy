using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	public int dmg = 20;

	void onTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			col.SendMessageUpwards("Damage", dmg);
		}

	}
}
