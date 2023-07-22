using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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
            //Debug.Log($"Fleshlight state: {PlayerLight.enabled}");
        }
    }
}