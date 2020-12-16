using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacastTargeting : MonoBehaviour
{
    [SerializeField] private Transform ShootPoint;
    private Vector2 ShootDirection;
    public BoxCollider2D MainHeroCollieder1;
    public CircleCollider2D MainHeroCollieder2;
    public MoveEnemy1 MoveHandler;
    public MoveEnemy1 MoveControll;

    void FixedUpdate()
    {
        float i = MoveEnemy1.horizontalMove;
        ShootDirection.x = i;
        ShootDirection.y = 0;
        int layer_mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(ShootPoint.position, ShootDirection*3, Mathf.Infinity, layer_mask);

        if (hit.collider == MainHeroCollieder1 || hit.collider == MainHeroCollieder2)
        {
            MoveControll.SeeHero = true;
            Debug.DrawRay(ShootPoint.position, ShootDirection, Color.green);
            MoveHandler.AimFire(ShootDirection);
        }
        else 
        {
            //print("flase");
            MoveControll.SeeHero = false;
        }
    }
}