using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLightPulse : MonoBehaviour
{
    public GameObject AffectedObject;
    public Light LightToAffect;

    public float maxSize;
    public float minSize;
    public float speed;

    void Update()
    {
        //The reciept 2.0
        AffectedObject.transform.localScale = new Vector3(Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize));
        LightToAffect.intensity = AffectedObject.transform.transform.localScale.x * 10;
    }
}
