using System.Collections;
using UnityEngine;

public class BloodCellAI : MonoBehaviour
{
    private GameObject gameManager;
    private Rigidbody rb;
    private int currentScore;
    private float moveSpeed;
    public Rigidbody body;
    public float maxForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("_GameManager");
        StartCoroutine(MoveCell());
    }

    IEnumerator MoveCell()
    {
        while (true)
        {
            currentScore = gameManager.GetComponent<Score>().score;

            Vector3 targetPosition = Camera.main.transform.position;
            Vector3 direction = (targetPosition - transform.position).normalized;

            moveSpeed = 8 + (currentScore / 200);
            rb.velocity = direction * moveSpeed;

            yield return new WaitForSeconds(1f);
        }
    }
}