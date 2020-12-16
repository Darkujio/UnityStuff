using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controlls : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement

	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 TargetVector)
	{
		Vector3 targetVelocity = TargetVector;
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
	}


	public void Flip()
	{
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
