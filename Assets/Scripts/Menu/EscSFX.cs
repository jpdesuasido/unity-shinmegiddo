using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscSFX : MonoBehaviour
{
    public AudioSource OnclickSFX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnclickSFX.Play();
        }
    }
}
