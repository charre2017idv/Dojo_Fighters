using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESIST : MonoBehaviour
{
   // public float Stamina;
    public float m_CurrStamina = 100;
    public float m_recoverSpeed=8;
    public float m_recoverSpeedInput=2;
    float m_time = 0;

    void Start()
    {
     //   m_CurrStamina = Stamina;
    }

    void Update()
    {
        //if (m_CurrStamina < 100)
        //{
        //    m_CurrStamina += (Time.deltaTime / 3);
        //}
        //if (m_CurrStamina > 100)
        //{
        //    m_CurrStamina = 100;
        //}
    }

    //Funcion para realizar daño al personaje desde otra entidad (Enemigo)


    public void resist()
    {
        if (m_CurrStamina < 100)
        {
            m_CurrStamina += (Time.deltaTime / 3);
        }
        if (m_CurrStamina > 100)
        {
            m_CurrStamina = 100;
        }
    }

    public void recover()
    {
        m_time += Time.deltaTime;
        if(m_time>1)
        {
            m_CurrStamina += m_recoverSpeed;
            m_time = 0;
        }

    }
}
