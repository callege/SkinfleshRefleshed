using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twitch : MonoBehaviour
{
    public float timeToWait = 1f;

    public void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timeToWait);
    }

    void Update()
    {
        waiter();
        transform.localScale = new Vector3(transform.localScale.x - 1, 0,transform.localScale.z - 1);
        waiter();
        transform.localScale = new Vector3(transform.localScale.x + 1, 0, transform.localScale.z + 1);
    }
}
