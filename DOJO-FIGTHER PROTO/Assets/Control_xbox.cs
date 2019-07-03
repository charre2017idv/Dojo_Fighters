using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_xbox : MonoBehaviour
{

    public Text text;

    void Update()
    {
        //Mapeado de botones   
        if (Input.GetButtonDown("BotonA"))//Condicionales para saber el boton correspondiente
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 0";
        }
        if (Input.GetButtonDown("BotonB"))
        {
            text.text = "Se pulso el boton 1";
        }
        if (Input.GetButtonDown("BotonX"))
        {
            text.text = "Se pulso el boton 2";
        }
        if (Input.GetButtonDown("BotonY"))
        {
            text.text = "Se pulso el boton 3";
        }
        if (Input.GetButtonDown("BotonZL"))
        {
            text.text = "Se pulso el boton 4";
        }
        if (Input.GetButtonDown("BotonZR"))
        {
            text.text = "Se pulso el boton 5";
        }
        if (Input.GetButtonDown("BotonBack"))
        {
            text.text = "Se pulso el boton 6";
        }
        if (Input.GetButtonDown("BotonStart"))
        {
            text.text = "Se pulso el boton 7";
        }
        if (Input.GetButtonDown("BotonLeftJoy"))
        {
            text.text = "Se pulso el boton 8";
        }
        if (Input.GetButtonDown("BotonRightJoy"))
        {
            text.text = "Se pulso el boton 9";
        }

        //Mapeado de joysticks, triggers
        float uno = Input.GetAxis("EjeX_izq");
        float dos = Input.GetAxis("EjeY_izq");
        float tres = Input.GetAxis("Gatillo_izq_derecha");
        float cuatro = Input.GetAxis("EjeX_derecho");
        float cinco = Input.GetAxis("EjeY_derecho");

        if (uno != 0)
        {
            text.text = "EjeX_izq = " + uno;
        }
        if (dos != 0)
        {
            text.text = "EjeY_izq = " + dos;
        }
        if (tres != 0)
        {
            if (tres == -1)
            {
                text.text = "Gatillo izquierdo = " + tres;
            }
            else if (tres == 1)
            {
                text.text = "Gatillo derecho = " + tres;
            }
        }
        if (cuatro != 0)
        {
            text.text = "EjeX_derecho = " + cuatro;
        }
        if (cinco != 0)
        {
            text.text = "EjeY_derecho = " + cinco;
        }
    }
}