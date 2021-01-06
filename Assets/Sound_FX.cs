using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_FX : MonoBehaviour
{
    public AudioSource AudioManager;
    public AudioClip Click_1;
    public AudioClip Click_2;

    public void Click_Sound_1()
    {
        AudioManager.PlayOneShot(Click_1);
    }


    public void Click_Sound_2()
    {
        AudioManager.PlayOneShot(Click_2);
    }

}
