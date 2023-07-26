using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Changed scene to {SceneName}");
        SceneManager.LoadScene(sceneName);
    }

    public void manualSceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}