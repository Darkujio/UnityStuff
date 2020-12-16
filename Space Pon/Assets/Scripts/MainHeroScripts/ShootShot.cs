using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShot : MonoBehaviour
{
    [SerializeField] private GameObject ShotPlace;	
    [SerializeField] private GameObject ShotPrefab;
    [SerializeField] private GameObject ShotAnim;
    public float ShotSpeed;
    public float FireRate;
    private bool FireReady;
    private float prevFire;
    private GameObject MainHeroObj;
    void Awake()
    {
        MainHeroObj = GameObject.Find("MainHeroObj");
        FireReady = true;
        prevFire = 0f;
    }
    void FixedUpdate()
    {
        float Fire = Input.GetAxisRaw("Fire1");
        prevFire = prevFire + Time.deltaTime;
        if (prevFire >= FireRate) FireReady = true;
        if (Fire!=0)
            {
                if (FireReady)
                {
                    ShotAnim.SetActive(true);
                }
            }
    }

    public void CreateShot()
    {
        Vector3 ShotPos = ShotPlace.transform.position;
        Vector2 ShotDirection = new Vector2();
        ShotDirection.x = ShotPlace.transform.position.x - MainHeroObj.transform.position.x;
        float ShotSpeedForShot = ShotSpeed;
        if (ShotDirection.x < 0) ShotSpeedForShot = -ShotSpeedForShot;
        GameObject Shot = Instantiate(ShotPrefab, ShotPos, Quaternion.identity);
        Rigidbody2D ShotBody = Shot.GetComponent<Rigidbody2D>();
        Vector2 ShotVector = new Vector2();
        if (ShotSpeedForShot<0)
        {
            Vector3 theScale = Shot.transform.localScale;
            theScale.x *= -1;
            Shot.transform.localScale = theScale;
        }
        ShotVector.x = ShotSpeedForShot;
        ShotVector.y = 0f;
        ShotBody.AddForce(ShotVector , ForceMode2D.Impulse);
        Destroy(Shot, 3);
        FireReady = false;
        prevFire = 0f;
    }
}
