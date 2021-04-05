using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class TouchHandler : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody MainCar;
    [HideInInspector]
    public Transform MainCarTr;
    [HideInInspector]
    public Transform Camera;
    public bool MovingCamera = true;

    [Header("Speed Attributes")]
    [Tooltip("Speed of movement from side to side")]
    public float SideSpeed = 4f;
    [Tooltip("Speed of consistent movement forward")]
    public float ForwardSpeed = 2.5f;

    [Header("Tech Attributes")]
    [Tooltip("This value represents the speed at which the car rotates during movement")]
    public float RotationSpeed = 10f;
    [Tooltip("This value represents the speed at which the car comes out of a skid")]
    public float StopCoeff = 5f;
    [Tooltip("Maximum rotation of car in degrees")]
    [Range(0f, 90f)]
    public float MaxRotation = 60f;
    [Tooltip("Float number, represents the minimal distance between car and touch/mouse before it would move in direction of mouse, recommended value is 0.5f")]
    [Range(0f, 5f)]
    public float MaxDeviation = 0.5f;


    private float width;
    private Vector3 BaseCameraPos;
    private Vector3 velocity = Vector3.zero;
    private float CarRotation;
    private float MaxSpeed;
    
    

    private Vector3 desiredVelocity;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        BaseCameraPos = Camera.position - new Vector3(MainCarTr.position.x,0,0); //Camera bounding to MainCar
        CarRotation = 0f;
        MaxSpeed = ForwardSpeed*1.5f;
    }


    void Update()
    {
        //Get touch imput
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            CalculateDesiredVelocityTouch(touch);  
        }
        else
        //Get mouth imput (unity testing)
        if (Input.GetButton("Fire1"))
        {
            CalculateDesiredVelocityMouse(Input.mousePosition); 
        } 
        else 
        {
            ForwardSpeed = MaxSpeed/1.5f;
            desiredVelocity = Vector3.zero;
        }
    }

    void FixedUpdate() 
    {
        if (MainCar != null)
        {//Main physix controller
        ForwardSpeed = ForwardSpeed + (MaxSpeed-ForwardSpeed) * Time.deltaTime * 0.2f;
        if (Input.touchCount > 0 || Input.GetButton("Fire1") && MovingCamera){
            MainCar.gameObject.GetComponent<CollusionHandle>().RotateCars(CarRotation, SideSpeed); //Send Rotation info to MainCar
            MainCar.velocity = desiredVelocity;
            Camera.position = Vector3.SmoothDamp(Camera.position, new Vector3(BaseCameraPos.x + MainCarTr.position.x,Camera.position.y,Camera.position.z), ref velocity, 0.5f);
        }
        else
        {
            if (MovingCamera)
            {
            MainCar.velocity = Vector3.zero;
            }
            else 
            {
                MainCar.gameObject.GetComponent<CollusionHandle>().RotateCars(0f, SideSpeed);
                MainCar.velocity = new Vector3(-ForwardSpeed, 0, 0);
            }
        }
        }
    }

    //Culculation of Machine Bundle movement velocity via Touch
    void CalculateDesiredVelocityTouch(Touch touch){
        if (MainCar != null)
        {
        Vector2 pos = new Vector2();
        pos.x = (touch.position.x - width) / width;
        Vector3 targetPosition = new Vector3(MainCar.position.x, MainCar.position.y, pos.x*5f); // Touch control from touch position on the screen
        Vector3 directionalVector = (targetPosition - MainCarTr.position).normalized * SideSpeed; //Velocity from direction and configurable speed
        if (Math.Abs(targetPosition.z - MainCarTr.position.z) < MaxDeviation){
            desiredVelocity = new Vector3(-ForwardSpeed, 0, 0);
            Vector3 CurrentVelocity = new Vector3(-ForwardSpeed, 0, MainCar.velocity.z + (desiredVelocity.z - MainCar.velocity.z) * Time.deltaTime * SideSpeed * StopCoeff); // Side velocity to zero
            desiredVelocity = CurrentVelocity;
            CarRotation = (desiredVelocity.z) / SideSpeed * MaxRotation; //Car rotation from Velocity
            return;
        }
        else desiredVelocity = directionalVector + new Vector3(-ForwardSpeed, 0,0);
        CarRotation = (desiredVelocity.z) / SideSpeed * MaxRotation; //Car rotation from Velocity
        }
    }
    //Unity testing mouse imput
    void CalculateDesiredVelocityMouse(Vector3 MousePos){
        if (MainCar != null)
        {
        Vector2 pos = new Vector2();
        pos.x = (MousePos.x - width) / width;
        Vector3 targetPosition = new Vector3(MainCar.position.x, MainCar.position.y, pos.x* 5f);
        Vector3 directionalVector = (targetPosition - MainCarTr.position).normalized * SideSpeed;
        if (Math.Abs(targetPosition.z - MainCarTr.position.z) < MaxDeviation){
            desiredVelocity = new Vector3(-ForwardSpeed, 0,0);
            Vector3 CurrentVelocity = new Vector3(-ForwardSpeed, 0, MainCar.velocity.z + (desiredVelocity.z-MainCar.velocity.z) * Time.deltaTime* SideSpeed * StopCoeff );
            desiredVelocity = CurrentVelocity;
            CarRotation = (desiredVelocity.z) / SideSpeed * MaxRotation;
            return;
        }
        else{
            desiredVelocity = directionalVector + new Vector3(-ForwardSpeed, 0,0);
            Vector3 CurrentVelocity = new Vector3(-ForwardSpeed, 0, MainCar.velocity.z + (desiredVelocity.z-MainCar.velocity.z) * Time.deltaTime* SideSpeed);
            desiredVelocity = CurrentVelocity;
        }
        CarRotation = (desiredVelocity.z) / SideSpeed * MaxRotation;
        }
    }
}
