using System.Collections;
using UnityEngine;

public class BloodCellAI : MonoBehaviour
{
    public Rigidbody body;
    public float maxForce;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoveCell());
    }

    //void Update()
    //{
        //float direction = Random.Range(0,2);
        //float appliedForce = Random.Range(-maxForce,maxForce);

        ////if (direction == 0)
        //{
        //    body.velocity = new Vector3(appliedForce,0,0);
        //}
        ////else if(direction == 1)
        //{
        //    body.velocity = new Vector3(0,appliedForce,0);
        //}
        //else if(direction == 1)
        //{
        //    body.velocity = new Vector3(0, 0, appliedForce);
        //}
    //}

    IEnumerator MoveCell()
    {
        while (true)
        {
            Vector3 targetPosition = Camera.main.transform.position;
            Vector3 direction = (targetPosition - transform.position).normalized;

            rb.velocity = direction * 15;

            yield return new WaitForSeconds(1f);
        }
    }
}