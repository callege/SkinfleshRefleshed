using UnityEngine;

public class BrainRotter : MonoBehaviour
{
    public float decreaseAmountPerSecond = 10f;

    private PlayerBrainRot playerBrainRot;
    public bool isColliding;

    private void Start()
    {
        playerBrainRot = FindObjectOfType<PlayerBrainRot>();
    }

    private void Update()
    {
        if (isColliding)
        {
            Debug.Log("Decreasing brain health");
            playerBrainRot.DecreaseBrainHealth(decreaseAmountPerSecond * Time.deltaTime);
        }
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