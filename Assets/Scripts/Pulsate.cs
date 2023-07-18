using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pulsate : MonoBehaviour
{
    public GameObject AffectedObject;
    //public Light LightToAffect;

    private float maxSize;
    //public float minSize;
    public float speed;

    private void Start()
    {
        maxSize = UnityEngine.Random.Range(2f, 4f);
    }

    void Update()
    {
        //The reciept 2.0
        AffectedObject.transform.localScale = new Vector3(Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize));
        //LightToAffect.intensity = AffectedObject.transform.transform.localScale.x * 10;
    }
}
