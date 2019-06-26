using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIT : MonoBehaviour
{
    public bool bIsHit = false;
    public Collider2D m_otherPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void OnTriggerStay2D(Collider2D collision)
    {
            bIsHit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bIsHit = false;
    }
}
