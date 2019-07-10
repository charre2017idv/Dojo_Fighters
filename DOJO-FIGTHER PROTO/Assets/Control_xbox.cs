using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control_xbox : MonoBehaviour
{
    //Una variable pública donde se usará en el archivo llamado "PLAYER_XBOX"
    public MOVEMENT m_move;
    //Esta variable sirve para poder mostrar en el Label el input ingresado y evitar ejecutar la consola para ver el input
    public Text text;

    void Update()
    {
        //Mapeado de los botones del control, en total son 10   
        //El botón que se ingrese es el que se mostrará en pantalla

        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonA"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 0";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonB"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 1";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonX"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 2";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonY"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 3";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonZL"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 4";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonZR"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 5";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonBack"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 6";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonStart"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 7";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonLeftJoy"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 8";
        }
        //Condición para saber el boton correspondiente
        if (Input.GetButtonDown("BotonRightJoy"))
        {
            //Se imprime el mensaje en la consola de Unity
            text.text = "Se pulso el boton 9";
        }

        //Mapeado de joysticks, triggers
        //En total de estos son cinco

        //Se crea una variable para que va a almacenar el input de un joystick o un trigger (gatillo)
        float uno = Input.GetAxis("EjeX_izq");
        float dos = Input.GetAxis("EjeY_izq");
        float tres = Input.GetAxis("Gatillo_izq_derecha");
        float cuatro = Input.GetAxis("EjeX_derecho");
        float cinco = Input.GetAxis("EjeY_derecho");

        //Dependiendo del input ingresado entrará en esta sección
        if (uno != 0)
        {
            //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
            text.text = "EjeX_izq = " + uno;
        }
        //Dependiendo del input ingresado entrará en esta sección
        if (dos != 0)
        {
            //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
            text.text = "EjeY_izq = " + dos;
        }
        //Dependiendo del input ingresado entrará en esta sección
        if (tres != 0)
        {
            //Una vez dentro analizará si el valor es positivo o negativo, esto influye para identificar que gatillo se presíonó
            if (tres == -1)
            {
                //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
                text.text = "Gatillo izquierdo = " + tres;
            }
            else if (tres == 1)
            {
                //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
                text.text = "Gatillo derecho = " + tres;
            }
        }
        //Dependiendo del input ingresado entrará en esta sección
        if (cuatro != 0)
        {
            //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
            text.text = "EjeX_derecho = " + cuatro;
        }
        //Dependiendo del input ingresado entrará en esta sección
        if (cinco != 0)
        {
            //Se imprime el mensaje en la consola de Unity, pero con sus decimales correspondientes
            text.text = "EjeY_derecho = " + cinco;
        }
    }
}