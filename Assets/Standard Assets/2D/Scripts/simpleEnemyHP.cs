using UnityEngine;
using System.Collections;

public class simpleEnemyHP : MonoBehaviour {
	public int maxHP = 10;
	public int curHP = 10;

	public GameObject player;
	public AudioClip sound;

	public void Start(){
		player = GameObject.Find("Player");
	}


	// Function is called from enemy when attacked
	public void AttackEnemy(int dmg){
		curHP-=dmg;
		if (curHP <= 0) {
			enemyDie();


		}

	}

	public void enemyDie(){
		player.SendMessage("addExp", 1);
		AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.volume = 0.1f;
		sound = audioSource.clip;
		AudioSource.PlayClipAtPoint (sound, transform.position);
		Destroy(gameObject);
	}
}
