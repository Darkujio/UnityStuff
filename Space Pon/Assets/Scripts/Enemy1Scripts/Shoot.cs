using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject ShotPlace;	
    [SerializeField] private GameObject ShotPrefab;
    public float ShotSpeed;
    public float FireRate;
    private float prevFire;
    private GameObject MainHeroObj;
    void Awake()
    {
        MainHeroObj = GameObject.Find("MainHeroObj");
        prevFire = 2f;
    }
    public void FireNow(Vector2 ShotDirection)
    {
        Vector3 ShotPos = ShotPlace.transform.position;
        prevFire = prevFire + Time.deltaTime;
        if (prevFire >= FireRate)
        {
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
            print (ShotVector);
            ShotBody.AddForce(ShotVector , ForceMode2D.Impulse);
            Destroy(Shot, 3);
            prevFire = 0f;
        }
    }
}
