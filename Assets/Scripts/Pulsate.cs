using UnityEngine;

public class Pulsate : MonoBehaviour
{
    private float maxSize;
    public float speed;

    private void Start()
    {
        maxSize = UnityEngine.Random.Range(2f, 4f);
    }

    void Update()
    {
        transform.localScale = new Vector3(Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize), Mathf.PingPong(Time.time * speed, maxSize));
    }
}