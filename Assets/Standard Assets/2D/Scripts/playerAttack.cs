using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;
	
	private float attackTimer = 0;
	private float attackCd = 0.1f;
	
	public Collider2D attackTrigger;
	
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

	void OnCollisionEnter2D(Collision2D coll){
		if (attacking && coll.gameObject.tag == "Enemy") {
			print("Player attacking");
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			//coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 0)*1000.0f);

		}
	}
}
