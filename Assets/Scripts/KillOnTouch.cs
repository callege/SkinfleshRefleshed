using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    //Borked death sounds, "respawn" sound plays on awake so that works anyway

    //public AudioSource deathSound;

    //public void Start()
    //{
        //StartCoroutine(waiter());
    //}

    //IEnumerator waiter()
    //{
    //    yield return new WaitForSeconds(2);
    //}

    public void OnTriggerEnter(Collider other)
    {
        //deathSound.Play();
        //waiter();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}