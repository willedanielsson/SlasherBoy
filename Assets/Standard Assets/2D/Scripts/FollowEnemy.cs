using UnityEngine;
using System.Collections;


public class FollowEnemy : MonoBehaviour
{
	
	private Vector2 movement;
	private Transform player;
	private float AIspeed = 5;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		//rotate to look at the player
		transform.eulerAngles = new Vector3 (0, 0, -transform.eulerAngles.z);
		transform.LookAt(player.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation

		//move towards the player
		if (Vector3.Distance(transform.position,player.position)>1f){//move if distance from target is greater than 1
			//transform.Translate(new Vector3(AIspeed* Time.deltaTime,0,0) );
			transform.position += (player.position - transform.position).normalized * AIspeed * Time.deltaTime;
		}

	}

	void FixedUpdate()
	{
		player = GameObject.FindWithTag ("Player").transform;
		// Apply movement to the rigidbody
		//GetComponent<Rigidbody2D>().velocity = movement;
	}
}
