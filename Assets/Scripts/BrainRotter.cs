using UnityEngine;

public class BrainRotter : MonoBehaviour
{
    public float decreaseAmountPerSecond = 10f;

    private PlayerBrainRot playerBrainRot;
    public bool isColliding;

    private void Start()
    {
        playerBrainRot = FindObjectOfType<PlayerBrainRot>();
        //StartDecreasing();
    }

    //private void StartDecreasing()
    //{
    //    StartCoroutine(DecreaseHealthCoroutine());
    //}

    private void Update()
    {
        if (isColliding)
        {
            Debug.Log("Decreasing brain health");
            playerBrainRot.DecreaseBrainHealth(decreaseAmountPerSecond * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("Is colliding");
        isColliding = true;
    }

    public void OnTriggerExit(UnityEngine.Collider other)
    {
        isColliding = false;
    }

    //private IEnumerator DecreaseHealthCoroutine()
    //{
    //    while (true)
    //   {
    //        playerBrainRot.DecreaseBrainHealth(decreaseAmountPerSecond * Time.deltaTime);
    //        yield return null; // Wait for the next frame
    //    }
    //}
}