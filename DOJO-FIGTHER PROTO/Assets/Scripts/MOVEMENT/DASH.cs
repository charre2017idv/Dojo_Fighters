using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASH : MonoBehaviour
{
    Rigidbody2D Player;
    SpriteRenderer MySprite;

    
    //public Collider2D Colliders;
    public float velocity;
    //private float directionInY;
    public float directionInX=0;

    // Dash

    public bool isDash = false;
    public float dashTimer;
    public float maxDash = .5f;
    public Vector2 savedVelocity;

    int Dstate=0;
    public enum dashState
    {
        Ready,
        Dashing,
        Cooldown
    }

    // Start is called before the first frame update
    void Start()
    {
        //MySprite = GetComponent<SpriteRenderer>();
        //Player = GetComponent<Rigidbody2D>();
        //Colliders = GetComponent<Collider2D>();
        //directionInX = velocity;
        //directionInY = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //inputs();
        //DashStates(Player, Colliders);
        //Player.velocity = new Vector2(directionInX, directionInY);
    }

    // Player Inputs
    void inputs()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionInX = velocity;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionInX = -velocity;
        }
        else
        {
            directionInX = 0;
           // directionInY = 0;
        }
    }

    public void dashDirection(float direction)
    {
        if (direction>0)
        {
            velocity = 0;
            directionInX = 50;
            //Vector2 ActualPos = new Vector2(transform.position.x + 3, -velocity);
            //transform.position = Vector2.Lerp(LastPos, ActualPos, 10.0f);
            Dstate = (int)dashState.Dashing;
            isDash = true;
            //PlayerBody.velocity = new Vector2(directionInX, directionInY);
        }
        else if (direction<0)
        {
            velocity = 0;
            directionInX = -50;
            Dstate = (int)dashState.Dashing;
            isDash = true;
            //PlayerBody.velocity = new Vector2(directionInX, directionInY);
        }
    }

    public void DashStates(Rigidbody2D PlayerBody, Collider2D playerCollider)
    {
        switch (Dstate)
        {
            case (int)dashState.Dashing:
                //Collider.enabled = false;   
                dashTimer += Time.deltaTime*3 ;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    // PlayerBody.velocity = savedVelocity;
                    Dstate = (int)dashState.Cooldown;
                    isDash = false;
                    playerCollider.isTrigger = false;
                    directionInX = 0;
                }
                else
                {
                    playerCollider.isTrigger =true;
                    PlayerBody.velocity = new Vector2(directionInX,0);
                }
                break;
            case (int)dashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    velocity = 5f;


                    Dstate = (int)dashState.Ready;
                   // playerCollider.enabled = true;

                }
                break;
        }

    }
}

/*public void DashStates(Rigidbody2D PlayerBody, Collider2D Collider)
{
        switch (Dstate)
        {
            case (int)dashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                //if (isDashKeyDown)
                //{
                //    directionInX  +=30;
                //    //velocity *= 3;
                //    //
                //    //savedVelocity = PlayerBody.velocity;
                //    //PlayerBody.velocity = new Vector2(velocity, -velocity);
                //    Dstate = (int)dashState.Dashing;
                //}
                //Vector2 LastPos = new Vector2(transform.position.x, -velocity);
                if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.D) && velocity < 10)
                {
                    velocity = 0;
                    directionInX = 50;
                    //Vector2 ActualPos = new Vector2(transform.position.x + 3, -velocity);
                    //transform.position = Vector2.Lerp(LastPos, ActualPos, 10.0f);
                    Dstate = (int)dashState.Dashing;
                    isDash = true;
                    //PlayerBody.velocity = new Vector2(directionInX, directionInY);
                }
                else if (Input.GetKey(KeyCode.O) && Input.GetKeyDown(KeyCode.A) && velocity < 10)
                {
                    velocity = 0;
                    directionInX = 50;
                    Dstate = (int)dashState.Dashing;
                    isDash = true;
                    //PlayerBody.velocity = new Vector2(directionInX, directionInY);
                }
                break;
            case (int)dashState.Dashing:
                //Collider.enabled = false;   
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    // PlayerBody.velocity = savedVelocity;
                    Dstate = (int)dashState.Cooldown;
                    isDash = false;
                    directionInX = 0;
                }
                break;
            case (int)dashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    velocity = 5f;


                    Dstate = (int)dashState.Ready;
                    Collider.enabled = true;

                }
                break;
        }

    
}*/
