using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;
	
	private float attackTimer = 0;
	private float attackCd = 0.1f;
	
	public Collider2D attackTrigger;
	public AudioClip sound;
	private Animator anim;
	
	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}
	
	void Update(){
		if (Input.GetKeyDown ("f") && !attacking) {
			attacking = true;
			attackTimer = attackCd;
			
			attackTrigger.enabled=true;
			playAttackSound();
		}
		
		if (attacking) {
			if(attackTimer > 0){
				attackTimer -= Time.deltaTime;
			}else{
				attacking=  false;
				attackTrigger.enabled = false;
			}
		}
		
		anim.SetBool ("Attacking", attacking);
	}

	private void playAttackSound(){
		AudioSource[] audioSources = gameObject.GetComponents<AudioSource> ();
		AudioSource attackSound = audioSources[0];
		attackSound.volume = 0.1f;
		sound = attackSound.clip;
		AudioSource.PlayClipAtPoint (sound, transform.position);
	}

	// SEE attackTrigger.cs for handling the collisions

/*	void OnCollisionEnter2D(Collision2D coll){
		if (attacking && coll.gameObject.tag == "Enemy") {
			print("Player attacking");
			//coll.gameObject.SendMessage("AttackEnemy", 10);
			//coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 0)*1000.0f);

		}
	}*/

}
