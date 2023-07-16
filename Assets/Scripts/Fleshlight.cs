using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleshlight : MonoBehaviour
{
    public Light PlayerLight;
    public AudioSource Click;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click.Play();
            PlayerLight.enabled = !PlayerLight.enabled;
        }
    }
}