using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = true;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private float m_DashForce = 400f;

	const float k_GroundedRadius = 0.07f; // Radius of the overlap circle to determine if grounded
	internal static bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private Vector3 currentGravity;
	private ContactPoint2D[] cPoints;
	private Collision2D newCol;
	private Vector3 groundNormal;
	private float maxGroundedAngle = 10f;
	public Vector3 MyGravity;
	public float DashSpeed = 5f;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
			}
		}
		ObeyGravity();
	}

	void OnCollisionStay2D(Collision2D other)
    {
		if (other.gameObject.name == "FirstFloorLevel" || other.gameObject.name == "SecondFloorLevel")
		{
			foreach (var contact in other.contacts)
			{
				if(maxGroundedAngle > Vector3.Angle(contact.normal, -Physics.gravity.normalized))
            	{
                	groundNormal = contact.normal;
            	}
				else groundNormal = -MyGravity;
			}	
		}
    }

	void ObeyGravity()
    {
        if(m_Grounded == false)
        {
            //normal gravity, active when not grounded.
            currentGravity = MyGravity;

        }
        else if(m_Grounded == true)
        {
            currentGravity = -groundNormal;
        }
        m_Rigidbody2D.AddForce(2*currentGravity, ForceMode2D.Force);
    }


	public void Move(float move, bool jump, bool dash)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			if (dash)
			{
				m_Rigidbody2D.constraints =RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			}
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}

			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

	public void Dash()
	{
		if (m_FacingRight)
		Move(DashSpeed * Time.fixedDeltaTime, false, true);
		else Move(-DashSpeed * Time.fixedDeltaTime, false, true);
	}

	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}