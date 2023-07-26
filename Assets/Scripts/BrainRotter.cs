using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BrainRotter : MonoBehaviour
{
    public float decreaseRate = 10f;
    //private float currentBrainHealth = GameObject.Find("Brain").GetComponent<PlayerBrainRot>().currentBrainHealth;
    //private float maxBrainHealth = GameObject.Find("Brain").GetComponent<PlayerBrainRot>().maxBrainHealth;

    void Update()
    {
        currentBrainHealth -= decreaseRate * Time.deltaTime;
        currentBrainHealth = Mathf.Clamp(currentBrainHealth, 0f, maxBrainHealth);
    }
}
