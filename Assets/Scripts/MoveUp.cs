using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float maxDistanceToMove;
    public float speed;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, maxDistanceToMove);
        Vector3 targetPosition = startPosition + new Vector3(0, offset, 0);

        transform.position = Vector3.Lerp(startPosition, targetPosition, offset / maxDistanceToMove);
    }
}