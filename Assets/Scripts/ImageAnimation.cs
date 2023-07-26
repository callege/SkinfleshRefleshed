using System.Collections;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    public float timeToWait;
    public GameObject[] images;

    public void Start()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
            yield return new WaitForSeconds(timeToWait);
            images[i].SetActive(false);
        }
    }
}