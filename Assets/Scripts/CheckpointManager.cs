using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 currentCheckpoint;
    public string checkpointName;
    public GameObject player;

    private void Start()
    {
        currentCheckpoint = new Vector3 (-209, 122, -89);
        checkpointName = "Spawn";
    }
}