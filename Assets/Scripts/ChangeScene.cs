using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Changed scene to {SceneName}");
        SceneManager.LoadScene(SceneName);
    }
}