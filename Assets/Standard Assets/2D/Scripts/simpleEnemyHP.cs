using UnityEngine;
using System.Collections;

public class simpleEnemyHP : MonoBehaviour {
	public int maxHP = 10;
	public int curHP = 10;
	// Function is called from enemy when attacked
	public void AttackEnemy(int dmg){
		curHP-=dmg;
		if (curHP <= 0) {
			Destroy(gameObject);

		}

	}
}
