using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericLightPulse : MonoBehaviour
{
    public Light LightToAffect;

    public float maxDist;
    public float speed;

    void Update()
    {
        LightToAffect.intensity = Mathf.PingPong(Time.time * speed, maxDist);
    }
}
