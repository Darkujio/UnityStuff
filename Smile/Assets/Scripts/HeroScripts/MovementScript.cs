using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField, Tooltip("RigidBody2D Object")]
    Rigidbody2D Body;
    [SerializeField, Tooltip("Character Speed")]
    float Speed;
    void FixedUpdate()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");
        Body.velocity = new Vector2(moveInputX * Speed , moveInputY * Speed);   
    }

    // НЕУДАЧНАЯ ПОПЫТКА
    // [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    // float speed = 9;
    // [SerializeField, Tooltip("Acceleration")]
    // float Acceleration = 75;
    // private Vector2 velocity;
    // private GameObject MainHeroObj;
    // private CapsuleCollider2D CapsuleCollider;

    // void Awake()
    // {
    //     MainHeroObj = GameObject.Find("MainHeroObj");
    //     CapsuleCollider = MainHeroObj.GetComponent<CapsuleCollider2D>();
    // }
    // void FixedUpdate()
    // {   НЕУДАЧНАЯ ПОПЫТКА
    //     float moveInputX = Input.GetAxisRaw("Horizontal");
    //     float moveInputY = Input.GetAxisRaw("Vertical");
    //     velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInputX, Acceleration * Time.deltaTime);
    //     velocity.y = Mathf.MoveTowards(velocity.y, speed * moveInputY, Acceleration * Time.deltaTime);
    //     MainHeroObj.transform.Translate(velocity * Time.deltaTime);
    //     Collider2D[] hits = Physics2D.OverlapCapsuleAll(transform.position, CapsuleCollider.size,CapsuleCollider.direction, 0);
    //     foreach (Collider2D hit in hits)
    //     {
	//         if (hit == CapsuleCollider) continue;
    //         if (hit.name == "ShotPrefab(Clone)") continue;
	//         ColliderDistance2D colliderDistance = hit.Distance(CapsuleCollider);
	//         if (colliderDistance.isOverlapped)
	//         {
	// 	        MainHeroObj.transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
	//         }
    //     }
    // } НЕУДАЧНАЯ ПОПЫТКА
}
