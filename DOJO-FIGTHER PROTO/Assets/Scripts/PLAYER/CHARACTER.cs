using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTER : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_damageLight;
    public float m_damageHeavy;
    public float m_damageEspecialLight;
    public float m_damageEspecialHeavy;
    public float m_damageEspecialEsquive;
    public float m_speed;
    public float m_reload;

    int fighter=0;
    enum character
    {
        boxeador,
        karateka,
    }
    void Start()
    {
        if (fighter==(int)character.boxeador)
        {
            chargeBoxeador();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chargeBoxeador()
    {
        m_damageLight=10;
        m_damageHeavy=20;
        m_damageEspecialLight=40;
        m_damageEspecialHeavy=60;
        m_damageEspecialEsquive=100;
        m_speed=8;
    }
}
