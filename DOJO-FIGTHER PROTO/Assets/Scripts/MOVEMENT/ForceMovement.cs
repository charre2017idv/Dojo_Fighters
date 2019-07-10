using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour
{
    public Vector2 Forcex;
    public Vector2 LimitVector;
    public Vector2 DashVector;
    public float SpeedLimit;
    Rigidbody2D MyRB;
    public float DashTime;
    float CurrDashTime;
    // Start is called before the first frame update
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();
        CurrDashTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrDashTime += Time.deltaTime;
        if(Input.GetKey(KeyCode.D))
        {
            MyRB.AddForce(Forcex, ForceMode2D.Force);
            if(MyRB.velocity.x > SpeedLimit)
            {
                MyRB.AddForce(-LimitVector, ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.F))
            {
                if (CurrDashTime > DashTime)
                {
                    MyRB.AddForce(DashVector, ForceMode2D.Impulse);
                    CurrDashTime = 0;
                }
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            MyRB.AddForce(-Forcex, ForceMode2D.Force);
            if (MyRB.velocity.x < -SpeedLimit)
            {
                MyRB.AddForce(LimitVector, ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.F))
            {
                if (CurrDashTime > DashTime)
                {
                    MyRB.AddForce(-DashVector, ForceMode2D.Impulse);
                    CurrDashTime = 0;
                }
            }
        }
    }
}