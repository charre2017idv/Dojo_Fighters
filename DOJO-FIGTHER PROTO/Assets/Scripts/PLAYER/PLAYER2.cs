﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER2 : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraShake Shake;
    public MOVEMENT m_move;
    public ATTACK m_attack;
    public DASH m_dash;
    public RESIST m_resist;
    public CHARACTER m_fighter;
    public BARRA_STAMINA m_barraStamina;
    public BARRA_STAMINA m_barraAura;
    public SoundManager m_sound;

    public Cartel m_myCartel;
    public Cartel m_otherCartel;

    public PLAYER ohterPlayer2;
    // Start is called before the first frame update

    Rigidbody2D m_rigid;
    BoxCollider2D m_bCollider;
    public float m_speed;

    bool lookright;
    bool b_isHurt=false;
    bool b_isMove;
    bool b_isAttack = false;
    public bool b_isKO = false;
    void Start()
    {

        //m_speed=10;
        m_move.m_velocidad = m_fighter.m_speed;
        m_rigid = GetComponent<Rigidbody2D>();
        m_bCollider = GetComponent<BoxCollider2D>();
        GetComponent<SpriteRenderer>().color = Color.blue;

    }

    void movement()
    {
        m_move.m_velocidad = m_fighter.m_speed;
        if (!b_isAttack)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                m_move.moveRigth();
            else if (Input.GetKey(KeyCode.LeftArrow))
                m_move.moveleft();
            else
                m_move.m_direccion = 0;
        }
        else
        {
            m_move.m_direccion = 0;
        }

        if (!b_isAttack && !m_dash.isDash)
            m_move.move(m_rigid);

    }

    void attack()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && !m_attack.bIsAttacking && !m_dash.isDash)
        {
            if (m_attack.bIsAuraActivated)
                m_sound.PlaySound(2);
            else
                m_sound.PlaySound(0);
            b_isAttack = true;
            m_attack.LightAttack(ref b_isHurt, m_fighter.m_damageLight, m_fighter.m_damageEspecialLight);
            // Invoke("CoolDown", 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) && !m_attack.bIsAttacking && !m_dash.isDash)
        {
            if (m_attack.bIsAuraActivated)
                m_sound.PlaySound(2);
            else
                m_sound.PlaySound(1);

            b_isAttack = true;
            m_attack.HeavyAttack(ref b_isHurt, m_fighter.m_damageHeavy, m_fighter.m_damageEspecialHeavy);
        }
        else if (Input.GetKeyUp(KeyCode.Keypad0) && !m_attack.bIsAttacking && !m_dash.isDash)
        {
            m_attack.ActivateAttack();
        }
        else if (Input.GetKeyUp(KeyCode.Keypad3) && m_attack.bIsAuraActivated)
        {
            if (m_attack.bIsAuraActivated)
                m_sound.PlaySound(2);
            m_attack.EspecialEsquiveAttack(ref b_isHurt, m_fighter.m_damageEspecialEsquive);
        }

        if (!m_attack.bIsAttacking)
        {
            b_isAttack = false;
        }
        else
            m_rigid.velocity = new Vector2(0, 0);
    }

    void dasher()
    {
        if (!m_attack.bIsAuraActivated)
        {
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                m_dash.dashDirection(m_move.m_direccion);
            }
            m_dash.DashStates(m_rigid, m_bCollider);
            m_move.dasher(m_rigid);

        }
    }
    void flip()
    {
        if (ohterPlayer2.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.identity;
        }
        if (ohterPlayer2.transform.position.x < GetComponent<Transform>().position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void flipOtherCartel()
    {
        if (m_otherCartel.transform.position.x > GetComponent<Transform>().position.x)
        {
            transform.rotation = Quaternion.identity;
        }
        if (m_otherCartel.transform.position.x < GetComponent<Transform>().position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    // Update is called once per frame
    void applyDamage()
    {
        Shake.Shakeit();
        ohterPlayer2.m_resist.m_CurrStamina -= m_attack.m_damage;
        Debug.Log("stamina p1: " + ohterPlayer2.m_resist.m_CurrStamina);
        b_isHurt = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!b_isKO)
        {
            if (m_attack.bIsAuraActivated)
            {

                GetComponent<SpriteRenderer>().color = Color.grey;
            }
            else
            {

                GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (ohterPlayer2.b_isKO)
                flipOtherCartel();
            else
                flip();
            attack();
            dasher();
            movement();
            if (b_isHurt)
                if (b_isHurt && !ohterPlayer2.b_isKO)
                {
                    applyDamage();
                    m_sound.PlaySound(5);
                }
                else if(b_isHurt)
                {
                    m_otherCartel.RealizarDaño(m_attack.m_damage);
                    if (m_otherCartel.mcurrentHP <= 0)
                        m_sound.PlaySound(3);
                    else
                        m_sound.PlaySound(4);
                    b_isHurt = false;
                }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
                m_resist.m_CurrStamina += m_resist.m_recoverSpeedInput;
            m_resist.recover();
            if (m_resist.m_CurrStamina >= 100)
            {
                m_rigid.bodyType = RigidbodyType2D.Dynamic;
                GetComponent<SpriteRenderer>().color = Color.blue;
                b_isKO = false;
                m_bCollider.isTrigger = false; ;

                m_myCartel.mIsenable = false;
                m_resist.m_recoverSpeed -= 2;
            }
        }

        m_barraStamina.ActualizarValorBarra(100, m_resist.m_CurrStamina);
        m_barraAura.ActualizarValorBarra(30, m_attack.auraTemporal);
        if (m_resist.m_CurrStamina <= 0&&!b_isKO)
        {
            m_rigid.bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().color = Color.magenta;

            //Destroy(this.gameObject);
            m_resist.m_CurrStamina = 0;
            m_myCartel.mIsenable = true;
            m_bCollider.isTrigger = true;
            b_isKO = true;
        }


        //  ifsasadasdadasda
        //    m_move.m_CurrentMovement();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="HIT")
        Debug.Log("ENTRO");
    }
}
