using UnityEngine;
using System.Collections;

public class JetpackEnemy : MonoBehaviour
{
	
	private Transform player;
	public float AIspeed = 5;
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character


	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	[SerializeField] private float m_JumpForce = 400f;
	private Vector2 movement;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_Grounded; 
	
	void Awake(){
		//Setup
		player = GameObject.FindWithTag ("Player").transform;
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		m_GroundCheck = transform.Find("GroundCheck");
		m_Grounded = false;
	}
	
	void Update()
	{

		if (transform.position.x < player.position.x) {
			movement = new Vector2 (
				AIspeed * 1,
				0);
		} else if (transform.position.x > player.position.x) {
			movement = new Vector2 (
				AIspeed * -1,
				0);
		}
		// If the player should jump...
		if (m_Grounded && player.position.y > transform.position.y+1
		    )
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}
	
	void FixedUpdate()
	{
		player = GameObject.FindWithTag ("Player").transform;
		// Apply movement to the rigidbody
		m_Rigidbody2D.velocity = movement;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}
	}
}
