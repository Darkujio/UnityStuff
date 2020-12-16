using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controll : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float MoveSpeed = 0.2f;
    [SerializeField] private float GravityScale = 5f;

    public Transform MovePoint;
    public Transform CheckFloor;
    public Transform Normal;
    public float ChangedSideTimerMax = 0.3f;

    private Vector3 groundNormal;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = false;
    private Vector3 PrevNormal;
    private Vector3 Moving = new Vector3(1f,0f,0f);
    private Vector3 currentGravity;
    private Vector3 MyGravity = new Vector3(0f,-1f,0f);
    private Vector2 EstimatedMoveVector;
    private Vector2 EstimatedNormalVector;
    private float MaxAngle = 80f;
    private ContactPoint2D contact;
    private float TempDirection;
    private float ChangedSideTimer = 0f;
    private Vector3 MoveVector;
    private float FlyStart = 0f;
    //private RaycastHit2D hitNormal;

    private bool LeftWall = false;
    private bool RightWall = false;
    private bool Ceiling = false;
    private bool Floor = false;
    private bool InAir = true;
    //private bool ChangedSide = false;
    private bool ChangedSideTrigger = false;
    private bool WantInAir = false;

    void Start()
    {
        m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        currentGravity = MyGravity * GravityScale;
    }


    void OnCollisionStay2D(Collision2D other)
    {
        // Air To Land behaviour
        if ((other.gameObject.name == "FirstFloorLevel" || other.gameObject.name == "SecondFloorLevel") & InAir)
		{
			foreach (ContactPoint2D contact in other.contacts)
			{
                if (contact.normal.y > 0.09f & !ChangedSideTrigger)
                {
                    InAir = false;
                    Floor = true;
                    Vector3 theScale = transform.localScale;
                    if (!m_FacingRight)
                    theScale.x = 1;
                    else theScale.x = -1;
                    Moving = new Vector3(1f, 0f, 0f);
                    transform.localScale = theScale;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
			}	
		}
        //Sticking to Walls behaviour
		if ((other.gameObject.name == "FirstFloorLevel" || other.gameObject.name == "SecondFloorLevel") & !InAir)
		{
			foreach (ContactPoint2D contact in other.contacts)
			{
                currentGravity = -contact.normal * GravityScale;
			}	
		}
    }
    void OnCollisionExit2D()
    {
        FlyStart = 0f;
        WantInAir = true;
    }

    void OnCollisionEnter2D()
    {
        WantInAir = false;
    }

    void FixedUpdate()
    {
        FlyStart += Time.deltaTime;
        if (FlyStart > 0.05f & WantInAir)
        {
            WantInAir = false;
            currentGravity = MyGravity*GravityScale;
            InAir = true;
            RightWall = false;
            LeftWall = false;
            Ceiling = false;
            Floor = false;
        }
    }


    void OutsideMoveOutDate()
    {
        // //STARTED OUTSIDE MOVEMENT LEGACY
        // //Floor To Left
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitDown.distance == 0 & Floor & !LeftWall & m_FacingRight & EstimatedMoveVector.x > 0.05 & EstimatedMoveVector.y < -0.05)
        // {
        //     LeftWall = true;
        //     Floor = false;
        //     Moving= new Vector3(0f,-1f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 270);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Left to Ceiling
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitLeft.distance == 0 & LeftWall & !Ceiling & m_FacingRight & EstimatedMoveVector.x < -0.05 & EstimatedMoveVector.y < -0.05)
        // {
        //     LeftWall = false;
        //     Ceiling =true;
        //     Moving= new Vector3(-1f,0f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 180);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Ceiling to Right
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitUp.distance == 0 & Ceiling & !RightWall & m_FacingRight & EstimatedMoveVector.x < -0.05 & EstimatedMoveVector.y > 0.05)
        // {
        //     Ceiling = false;
        //     RightWall =true;
        //     Moving= new Vector3(0f,1f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 90);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Right To Floor
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitLeft.distance == 0 & RightWall & !Floor & m_FacingRight & EstimatedMoveVector.x > 0.05 & EstimatedMoveVector.y > 0.05)
        // {
        //     RightWall = false;
        //     Floor =true;
        //     Moving= new Vector3(1f,0f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        //     ChangedSide = true;
        //     //print("trigger");
        // }


        // //Floor To Right
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitDown.distance == 0 & Floor & !LeftWall & !m_FacingRight & EstimatedMoveVector.x < -0.05 & EstimatedMoveVector.y < -0.05)
        // {
        //     RightWall = true;
        //     Floor = false;
        //     Moving= new Vector3(0f,1f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 90);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Right to Ceiling
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitRight.distance == 0 & RightWall & !Ceiling & !m_FacingRight & EstimatedMoveVector.x > 0.05 & EstimatedMoveVector.y < -0.05)
        // {
        //     RightWall = false;
        //     Ceiling =true;
        //     Moving= new Vector3(-1f,0f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 180);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Ceiling to Left
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitUp.distance == 0 & Ceiling & !LeftWall & !m_FacingRight & EstimatedMoveVector.x > 0.05 & EstimatedMoveVector.y > 0.05)
        // {
        //     Ceiling = false;
        //     LeftWall =true;
        //     Moving= new Vector3(0f,-1f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 270);
        //     ChangedSide = true;
        //     //print("trigger");
        // }

        // //Left To Floor
        // EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        // if (hitUp.distance == 0 & LeftWall & !Floor & !m_FacingRight & EstimatedMoveVector.x < -0.05 & EstimatedMoveVector.y > 0.05)
        // {
        //     LeftWall = false;
        //     Floor =true;
        //     Moving= new Vector3(1f,0f,0f);
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        //     ChangedSide = true;
        //     //print("trigger");
        // }
        // //ENDED OUTSIDE MOVEMENT
        // if (ChangedSide)
        // {
        //     TempDirection = direction;
        //     ChangedSideTrigger = true;
        //     ChangedSide = false;
        //     ChangedSideTimer = 0f;
        // }
        // ChangedSideTimer += Time.deltaTime;
        // if (ChangedSideTimer > ChangedSideTimerMax)
        // {
        //     ChangedSideTrigger = false;
        // }

    }

    void InsideMove(float direction)
    {
        int layer_mask = LayerMask.GetMask("StaticObjects");
        RaycastHit2D hitLeft = Physics2D.Raycast(gameObject.transform.position, -Vector2.right, 0.1f, layer_mask);
        RaycastHit2D hitDown = Physics2D.Raycast(gameObject.transform.position,-Vector2.up, 0.1f, layer_mask);
        RaycastHit2D hitRight = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 0.1f, layer_mask);
        RaycastHit2D hitUp = Physics2D.Raycast(gameObject.transform.position,Vector2.up, 0.1f, layer_mask);
        RaycastHit2D hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);

        //STARTED INSIDE MOVEMENT
        // Straight To Left Wall

        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if ((hitLeft.distance < 0.07 & hitLeft.distance > 0.05) & !LeftWall & Floor & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth6");
            gameObject.transform.Rotate(0,0,270);
            LeftWall = true;
            Floor = false;
            Moving = new Vector3(0f,-1f,0f);
        }

        //Straight To Right Wall
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if ((hitRight.distance < 0.07 & hitRight.distance > 0.05) & !RightWall & Floor & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth2");
            gameObject.transform.Rotate(0,0,90);
            RightWall = true;
            Floor = false;
            Moving = new Vector3(0f,1f,0f);
        }

        //Ceiling From Left
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (LeftWall & (hitUp.distance < 0.07 & hitUp.distance > 0.05) & !Ceiling & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth1");
            gameObject.transform.Rotate(0,0,270);
            Ceiling = true;
            LeftWall = false;
            Moving = new Vector3(-1f,0f,0f);
        }

        //Ceiling From Right
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (RightWall & (hitUp.distance < 0.07 & hitUp.distance > 0.05) & !Ceiling & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth3");
            gameObject.transform.Rotate(0,0,90);
            Ceiling = true;
            RightWall = false;
            Moving = new Vector3(-1f,0f,0f);
        }

        //Ceiling To Right
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (Ceiling & (hitRight.distance < 0.07 & hitRight.distance > 0.05) & !RightWall & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth4");
            gameObject.transform.Rotate(0,0,-90);
            Ceiling = false;
            RightWall = true;
            Moving = new Vector3(0f,1f,0f);
        }

        //Ceiling To Left
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (Ceiling & (hitLeft.distance < 0.07 & hitLeft.distance > 0.05) & !LeftWall & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth5");
            gameObject.transform.Rotate(0,0,90);
            Ceiling = false;
            LeftWall = true;
            Moving = new Vector3(0f,-1f,0f);
        }

        //Right to Floor
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (!Floor & (hitRight.distance < 0.07 & hitRight.distance > 0.05) & RightWall & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth7");
            gameObject.transform.Rotate(0,0,-90);
            RightWall = false;
            Floor = true;
            Moving = new Vector3(1f,0f,0f);
        }

        //Left to Floor
        EstimatedMoveVector = MovePoint.position - gameObject.transform.position;
        hitforward = Physics2D.Raycast(gameObject.transform.position,EstimatedMoveVector, 0.1f, layer_mask);
        if (!Floor & (hitLeft.distance < 0.07 & hitLeft.distance > 0.05) & LeftWall & (hitforward.distance < 0.07 & hitforward.distance > 0.05))
        {
            //print("smth8");
            gameObject.transform.Rotate(0,0,90);
            LeftWall = false;
            Floor = true;
            Moving = new Vector3(1f,0f,0f);
        }
        // FINISHED INSIDE MOVEMENT
    }

    void OutsideMove(float direction)
    {
        //TODO OUTSIDE WITH TRIGGER
    }
    public void Move(float direction)
    {
        if (InAir)
        {
            return;
        }
        else 
        {
            InsideMove(direction);
            OutsideMove(direction);
        }
        //Finished move
        if (direction>0 & !m_FacingRight)
        {
            Flip();
        }
        if (direction<0 & m_FacingRight)
        {
            Flip();
        }
        MoveVector = Moving*direction*MoveSpeed;
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, MoveVector, ref m_Velocity, m_MovementSmoothing);
    }

    //Used From Patrol and Behaviour
    public void ObeyGravity()
    {
        m_Rigidbody2D.AddForce(currentGravity, ForceMode2D.Force);
    }

    //Flip Character LocalScale to match the movement direction
    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }
}
