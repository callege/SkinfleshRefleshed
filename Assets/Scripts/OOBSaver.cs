using UnityEngine;
using UnityEngine.SceneManagement;

public class OOBSaver : MonoBehaviour
{
    public GameObject player;
    public float deathZone = -1000f;

    void Update()
    {
        if(player.transform.position.y < deathZone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}