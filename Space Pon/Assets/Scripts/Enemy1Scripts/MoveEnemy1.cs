using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy1 : MonoBehaviour
{
    [SerializeField] private Transform HoleCheck;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private LayerMask m_WhatIsFloor;
    public Shoot ShootHandler;
    private bool HoleAhead;  //HoleAhead or No
    public EnemyControll controller;
    public float runSpeed = 40f;
    public static float horizontalMove = 1f;
    const float CheckRadius = 0.01f;
    public bool SeeHero = false;
    public Rigidbody2D RB;
    private float Agro = 0f;
    private bool ShootTrigger;
    public static Vector2 ShootDirectionFinal;
    void FixedUpdate ()
    {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(WallCheck.position, CheckRadius, m_WhatIsFloor);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				controller.Flip();
                horizontalMove = -horizontalMove;
			}
		}
        Collider2D[] colliders2 = Physics2D.OverlapCircleAll(HoleCheck.position, CheckRadius, m_WhatIsFloor);
        if (colliders2.Length < 1)
        {
            controller.Flip();
                horizontalMove = -horizontalMove;
        }
        if (SeeHero) 
        {
            RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Agro = 0f;
            ShootHandler.FireNow(ShootDirectionFinal);
        }
        if (!SeeHero) 
        {
            Agro = Agro + Time.fixedDeltaTime;
            if (Agro > 1)
            {
                RB.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                ShootHandler.FireNow(ShootDirectionFinal);
            }
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime);
    }
    public void AimFire(Vector2 ShootDirection)
    {
        ShootDirectionFinal = ShootDirection;
    }
}
