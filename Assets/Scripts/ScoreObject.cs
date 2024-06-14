using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("_GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GetComponent<Score>().ChangeScore(100);
            Destroy(gameObject);
        }
    }
}