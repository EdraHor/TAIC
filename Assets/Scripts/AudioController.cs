using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource AudioFx;
    public AudioClip HoverFx;
    public AudioClip ClickFx;

    public void HoverSound()
    {
        AudioFx.PlayOneShot(HoverFx);
    }

    public void ClickSound()
    {
        AudioFx.PlayOneShot(ClickFx);
    }
}
