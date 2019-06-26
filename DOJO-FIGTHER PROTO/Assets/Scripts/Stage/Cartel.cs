using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour
{
    // Start is called before the first frame update
    public float mMaxHP = 200;      //Variable para HP máximo
    public float mcurrentHP;         //Variable para HP actual
    public bool mIsenable = false;
    public SoundManager m_sound;
    // Start is called before the first frame update
    void Start()
    {
        mcurrentHP = mMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (mcurrentHP <=0)     //Se revisa si el cartel aun cuenta con HP
        {
            
            GetComponent<SpriteRenderer>().color = Color.red;
            Application.Quit();

            //TODO  Enviar mensaje al Game Manager de que la partida ha concluido
        }
        else if (mcurrentHP <= mMaxHP / 4)
        {
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
        else if (mcurrentHP<=mMaxHP/2)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
       // if (Input.GetKey(KeyCode.Space)) //Condicion para activar la deteccion de golpes en el cartel
       // {
       //     mIsenable = !mIsenable;
       // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mIsenable)
        {
            print(collision.gameObject.name);
            print(mcurrentHP);
        }
    }

    public void RealizarDaño(float Daño)
    {
        mcurrentHP -= Daño;
    }
}
