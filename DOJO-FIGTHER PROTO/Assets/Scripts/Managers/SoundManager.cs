using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip m_AClightPunch, m_ACmediumPunch, m_ACspecialPunch, m_ACwin, m_ACdamageCartel, m_ACdamageTaken;
    public AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {

        ////Initialization of the AudioClips Variables
        //m_AClightPunch = Resources.Load<AudioClip>("light_punch");
        //m_ACmediumPunch = Resources.Load<AudioClip>("medium_punch");
        //m_ACspecialPunch = Resources.Load<AudioClip>("special_punch");
        //m_ACwin = Resources.Load<AudioClip>("win");
        //m_ACdamageCartel = Resources.Load<AudioClip>("damage_cartel");
        //m_ACdamageTaken = Resources.Load<AudioClip>("damage_taken");

        //audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function that switches the sound depending on the passed string *To call it: SoundManager.PlaySound("name_of_the_clip");
    public void PlaySound(int numSound)
    {
        //audioSrc = GetComponent<AudioSource>();
        switch (numSound)
        {
            case 0:
                audioSrc.PlayOneShot(m_AClightPunch);
                break;
            case 1:
                audioSrc.PlayOneShot(m_ACmediumPunch);
                break;
            case 2:
                audioSrc.PlayOneShot(m_ACspecialPunch);
                break;
            case 3:
                audioSrc.PlayOneShot(m_ACwin);
                break;
            case 4:
                audioSrc.PlayOneShot(m_ACdamageCartel);
                break;
            case 5:
                audioSrc.PlayOneShot(m_ACdamageTaken);
                break;
        }
    }
}
