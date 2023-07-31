using System.Collections;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateAmount = 0.1f;
    public float timeToWait = 0.1f;

    void Start()
    {
        StartCoroutine(rotate());
    }

    IEnumerator rotate()
    {
        while(true)
        {
            transform.Rotate(Vector3.up, +rotateAmount);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}