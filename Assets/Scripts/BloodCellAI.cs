using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BloodCellAI : MonoBehaviour
{
    public Rigidbody body;
    public float maxForce;

    void Update()
    {
        float direction = Random.Range(0,2);
        float appliedForce = Random.Range(-maxForce,maxForce);

        if (direction == 0)
        {
            body.velocity = new Vector3(appliedForce,0,0);
        }
        else if(direction == 1)
        {
            body.velocity = new Vector3(0,appliedForce,0);
        }
        else if(direction == 1)
        {
            body.velocity = new Vector3(0, 0, appliedForce);
        }
    }
}