using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public AudioSource btnSounds;
    public AudioClip hoverSound;

    public void HoverSound()
    {
        btnSounds.PlayOneShot(hoverSound);
    }
}
