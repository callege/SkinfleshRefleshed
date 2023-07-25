using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    public float timeToWait;
    public GameObject[] images;

    public void Start()
    {
        StartCoroutine(doTheThing());
    }

    IEnumerator doTheThing()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
            yield return new WaitForSeconds(timeToWait);
            images[i].SetActive(false);
        }
    }
}