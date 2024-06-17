using System.Collections;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private GameObject gameManager;
    private float xChangeVal;
    private float zChangeVal;
    public MeshRenderer meshRenderer;
    public Collider thingCollider;
    public AudioSource sound;

    private void Start()
    {
        gameManager = GameObject.Find("_GameManager");

        xChangeVal = transform.position.x + Random.Range(-8, 8);
        zChangeVal = transform.position.z + Random.Range(-8, 8);

        transform.position = new Vector3(xChangeVal, transform.position.y, zChangeVal);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thingCollider.enabled = false;
            gameManager.GetComponent<Score>().ChangeScore(100);
            gameManager.GetComponent<Timer>().ChangeTime(4);
            meshRenderer.enabled = false;
            sound.Play();
            StartCoroutine(RespawnThing());
        }
    }

    IEnumerator RespawnThing()
    {
        yield return new WaitForSeconds(8f);
        thingCollider.enabled = true;
        meshRenderer.enabled = true;
    }
}