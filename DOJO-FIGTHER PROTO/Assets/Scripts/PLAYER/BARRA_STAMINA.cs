using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BARRA_STAMINA : MonoBehaviour
{
    Slider BarraStamina;
    public float max;
    public float act;
    int cont = 0;

    void Awake()
    {
        BarraStamina = GetComponent<Slider>();    
    }
    // Start is called before the first frame update
    void Start()
    {
       // getStamina();
    }

    // Update is called once per frame
    void Update()
    {
        //ActualizarValorBarra(max, act);
    }

    public void ActualizarValorBarra(float valorMax, float valorAct)
    {
        float porcentaje;
        porcentaje = valorAct / valorMax;
        BarraStamina.value = porcentaje;
    }

    void getStamina()
    {
        if (cont <= 0)
        {
            ActualizarValorBarra(100, cont);
            cont++;
        }
        else
        {
            cont = 0;
        }
        Invoke("getStamina", 1f);
    }

}
