using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*!
 *\author Yhaliff Said Barraza Zubia 
 * \version 0.01 
 * \date 06/March/2019
 * \class CMovement CMovement.cs
    */

/// <summary>
/// This Class will be in-charge of the 
/// movement for all character of game and will 
/// generate most thing needed for itself but the variable 
/// m_gameObj will need to be attached to the obj you want 
/// to use 
/// </summary>
public class MOVEMENT : MonoBehaviour
{
    public DASH m_dash;
    //public Rigidbody2D m_Body = null;

    //public float m_dashSpeed;
    //public float m_Speed;

    public float m_direccion;
    public float m_velocidad;

 //   public enum Movement
 //   {
 //       None, //!< When the player is doing nothing 
 //       Right,/*!<for moving Right*/
 //       Left,/*!< for moving Left */
 //       dashLeft,/*!<makes the player dash in the direction mentioned*/
 //       dashRight,/*!<makes the player dash in the direction mentioned*/
 //       dodge/*!< controls the dodge motion */
 //   }

//    public Movement m_CurrentMovement;
//
//
//    // Start is called before the first frame update
//    void Start()
//    {
//        //m_Body = GetComponent<Rigidbody2D>();
//        //direccion = velocidad;
//    }

    public void moveRigth()
    {
        m_direccion = m_velocidad;
    }
    public void moveleft()
    {
        m_direccion = -m_velocidad;
    }
    public void move(Rigidbody2D m_Body)
    {
        m_Body.velocity = new Vector2(m_direccion, 0); //moverse en X
    }
     public void dasher(Rigidbody2D m_Body)
    {
        //m_direccion = m_dash.directionInX;
        //m_Body.velocity = new Vector2(m_direccion, 0); //moverse en X
    }
    

}