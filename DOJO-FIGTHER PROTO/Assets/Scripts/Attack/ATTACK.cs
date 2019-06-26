using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACK : MonoBehaviour
{


    public bool bIsAttacking = false;
    public bool bIsAuraActivated = false;

    Collider2D m_ActualAttackCollider;
    public Collider2D m_lightAttackCollider;
    public Collider2D m_heavyAttackCollider;
    public Collider2D m_SpecialLightAttackCollider;
    public Collider2D m_SpecialHeavyAttackCollider;
    public Collider2D m_SpecialEsquiveAttackCollider;

    public float LightCooldown = 0.3f;
    public float SpecialLightCooldown = 1.0f;
    public float HeavyCooldown = 0.75f;
    public float SpecialHeavyCooldown = 1.2f;
    public float SpecialEsquiveCooldown = 1.5f;

    public float m_damage = 0;

    public int auraTemporal = 0; //clampear aura* 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(auraTemporal>=30)
        {
            auraTemporal = 30;
        }
    }

    //ataque ligero
    public void LightAttack(ref bool isHurt, float damage, float EspecialDamage)
    {
        if ( !bIsAttacking)
        {
            if (!bIsAuraActivated)//ataque normal
            {
                bIsAttacking = true;
                m_ActualAttackCollider = m_lightAttackCollider;
                Invoke("CoolDown", LightCooldown);
                m_lightAttackCollider.GetComponent<SpriteRenderer>().enabled = true;
                m_lightAttackCollider.enabled = true;
                if (m_lightAttackCollider.GetComponent<HIT>().bIsHit&&!isHurt)//////////////////////////////////////////
                {

                    Debug.Log("HIT Light");
                    m_lightAttackCollider.GetComponent<HIT>().bIsHit = false;
                    isHurt = true;
                    m_damage = damage;
                    /*
                        activar animacion de recibir golpe en jugador 2 aqui
                            jugador2.m_vida -= 3
                        isHit = false
                        Jugador1.m_aura +=  2
                        Jugador2.m_aura += 1;
                    */
                    Debug.Log("Aura: " + auraTemporal);
                    auraTemporal += 2;
                }
                //jugador1.m_Stamina -= 10
            }
            else if(!isHurt) //Especial Ligero
            {
                if (!bIsAttacking && auraTemporal >= 10)
                {
                    bIsAttacking = true;
                    m_ActualAttackCollider = m_SpecialLightAttackCollider;
                    Invoke("CoolDown", SpecialLightCooldown);//duracion especial
                    m_SpecialLightAttackCollider.GetComponent<SpriteRenderer>().enabled = true;
                    m_SpecialLightAttackCollider.enabled = true;
                    if (m_SpecialLightAttackCollider.GetComponent<HIT>().bIsHit)
                    {
                        m_SpecialLightAttackCollider.GetComponent<HIT>().bIsHit = false;
                        Debug.Log("HIT Special Light");
                        isHurt = true;
                        m_damage = EspecialDamage;
                        /*
                            activar animacion de recibir golpe en jugador 2 aqui
                            jugador2.m_vida -= 20
                            Jugador2.m_aura += 1;
                        */
                        Debug.Log("Aura: " + auraTemporal);
                    }
                    bIsAuraActivated = false;
                    //jugador1.m_Stamina -= 25
                }
                else
                {
                    bIsAuraActivated = false;
                    Debug.Log("Aura insuficiente");
                }
                auraTemporal -= 10;
            }

        }

    }

    //ataque pesado
    public void HeavyAttack(ref bool isHurt, float damage, float EspecialDamage)
    {
        if (!bIsAttacking&& !isHurt)
        {
            if (!bIsAuraActivated)
            {
                bIsAttacking = true;
                m_ActualAttackCollider = m_heavyAttackCollider;
                Invoke("CoolDown", HeavyCooldown);
                m_heavyAttackCollider.GetComponent<SpriteRenderer>().enabled = true;
                m_heavyAttackCollider.enabled = true;
                if (m_heavyAttackCollider.GetComponent<HIT>().bIsHit)
                {
                    Debug.Log("HIT Heavy");
                    m_heavyAttackCollider.GetComponent<HIT>().bIsHit = false;
                    isHurt = true;
                    m_damage = damage;
                    /*
                        activar animacion de recibir golpe en jugador 2 aqui
                            jugador2.m_vida -= 10
                        isHit = false
                        Jugador1.m_aura +=  5
                        Jugador2.m_aura += 3;
                    */
                    auraTemporal += 5;
                    Debug.Log("Aura: " + auraTemporal);
                }
                //jugador1.m_Stamina -= 25
            }
            else if(!isHurt)
            {
                if (!bIsAttacking && auraTemporal >= 20)
                {
                    bIsAttacking = true;
                    m_ActualAttackCollider = m_SpecialHeavyAttackCollider;
                    Invoke("CoolDown", SpecialHeavyCooldown);//duracion especial
                    m_SpecialHeavyAttackCollider.GetComponent<SpriteRenderer>().enabled = true;
                    m_SpecialHeavyAttackCollider.enabled = true;
                    if (m_SpecialHeavyAttackCollider.GetComponent<HIT>().bIsHit)
                    {
                        m_SpecialHeavyAttackCollider.GetComponent<HIT>().bIsHit = false;
                        Debug.Log("HIT Heavy special");
                        isHurt = true;
                        m_damage = EspecialDamage;
                        /*
                            activar animacion de recibir golpe en jugador 2 aqui
                            jugador2.m_vida -= 20
                            Jugador2.m_aura += 1;
                        */
                        Debug.Log("Aura: " + auraTemporal);
                    }
                    bIsAuraActivated = false;
                    auraTemporal -= 20;
                    //jugador1.m_Stamina -= 25
                }
                else
                {
                    bIsAuraActivated = false;
                    Debug.Log("Aura insuficiente");
                }
            }
        }
    }

    public void EspecialEsquiveAttack(ref bool isHurt, float damage)
    {
        if (!bIsAttacking && auraTemporal >= 30&&!isHurt)
        {
            bIsAttacking = true;
            m_ActualAttackCollider = m_SpecialEsquiveAttackCollider;
            Invoke("CoolDown", SpecialEsquiveCooldown);//duracion especial
            m_SpecialEsquiveAttackCollider.GetComponent<SpriteRenderer>().enabled = true;
            m_SpecialEsquiveAttackCollider.enabled = true;
            if (m_SpecialEsquiveAttackCollider.GetComponent<HIT>().bIsHit)
            {
                m_SpecialEsquiveAttackCollider.GetComponent<HIT>().bIsHit = false;
                Debug.Log("HIT Special Light");
                isHurt = true;
                m_damage = damage;
                /*
                    activar animacion de recibir golpe en jugador 2 aqui
                    jugador2.m_vida -= 20
                    Jugador2.m_aura += 1;
                */
                Debug.Log("Aura: " + auraTemporal);
            }
            auraTemporal -= 30;
            bIsAuraActivated = false;
            //jugador1.m_Stamina -= 25
        }
        else
        {
            bIsAuraActivated = false;
            Debug.Log("Aura insuficiente");
        }
    }

    public void ActivateAttack()//activar aura
    {
     
            bIsAuraActivated = !bIsAuraActivated;
            Debug.Log(bIsAuraActivated);
        
    }


    void CoolDown()
    {
        m_ActualAttackCollider.GetComponent<SpriteRenderer>().enabled = false;
        //m_ActualAttackCollider.enabled = false;
       // m_ActualAttackCollider.GetComponent<HIT>().bIsHit = true;

        bIsAttacking = false;
    }
}
