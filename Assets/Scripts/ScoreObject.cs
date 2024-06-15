using System.Collections;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private GameObject gameManager;
    public MeshRenderer meshRenderer;
    public Collider collider;
    public AudioSource sound;

    private void Start()
    {
        gameManager = GameObject.Find("_GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collider.enabled = false;
            gameManager.GetComponent<Score>().ChangeScore(100);
            meshRenderer.enabled = false;
            sound.Play();
            StartCoroutine(DestroyThing());
        }
    }

    IEnumerator DestroyThing()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}