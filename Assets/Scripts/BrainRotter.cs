using UnityEngine;

public class BrainRotter : MonoBehaviour
{
    private PlayerBrainRot playerBrainRot;

    private void Start()
    {
        playerBrainRot = FindObjectOfType<PlayerBrainRot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerBrainRot.StopIncreaseCoroutine();
        playerBrainRot.SetIsColliding(true);
    }

    private void OnTriggerExit(Collider other)
    {
        playerBrainRot.SetIsColliding(false);
    }
}