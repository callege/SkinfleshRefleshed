using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundOnTouch : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<AudioSource>().Play();
    }
}