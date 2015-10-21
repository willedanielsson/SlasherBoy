using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	public static int dmg = 10;

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			col.SendMessageUpwards("AttackEnemy", dmg);
		}
	}
}

