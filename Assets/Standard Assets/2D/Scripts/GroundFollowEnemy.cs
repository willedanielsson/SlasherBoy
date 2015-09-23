using UnityEngine;
using System.Collections;

public class GroundFollowEnemy : MonoBehaviour
{
	
	private Transform player;
	public float AIspeed = 5;
	
	private Vector2 movement;
	private Rigidbody2D m_Rigidbody2D;

	void Awake(){
		player = GameObject.FindWithTag ("Player").transform;
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update()
	{
		//transform.Translate(new Vector3(AIspeed* Time.deltaTime,0,0) );
		if (transform.position.x < player.position.x) {
			movement = new Vector2 (
			AIspeed * 1,
			0);
		} else if (transform.position.x > player.position.x) {
			movement = new Vector2 (
				AIspeed * -1,
				0);
		}
	}
	
	void FixedUpdate()
	{
		player = GameObject.FindWithTag ("Player").transform;
		// Apply movement to the rigidbody
		m_Rigidbody2D.velocity = movement;
	}
}
