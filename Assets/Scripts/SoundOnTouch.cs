using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundOnTouch : MonoBehaviour
{
    //public GameObject soundEffect;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched");
        GetComponentInParent<AudioSource>().Play();
    }
}