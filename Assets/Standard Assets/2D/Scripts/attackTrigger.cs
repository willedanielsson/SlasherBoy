using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	public static int dmg = 10;

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && col.CompareTag ("Enemy")) {
			col.SendMessageUpwards("AttackEnemy", dmg);
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (4, 0) * 500.0f);
		}
		else if (col.isTrigger != true && col.CompareTag ("FlyEnemy")) {
			col.SendMessageUpwards("AttackEnemy", dmg);
			col.SendMessage("Attacked");
		}
	}

}

