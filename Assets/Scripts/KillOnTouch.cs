using UnityEngine.SceneManagement;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}