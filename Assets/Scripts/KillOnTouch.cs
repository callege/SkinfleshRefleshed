using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public GameObject player;
    public CheckpointManager checkpointManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched");
        Debug.Log(checkpointManager.currentCheckpoint);
        player.SetActive(false);
        player.transform.position = checkpointManager.currentCheckpoint;
        player.SetActive(true);
    }
}