using UnityEngine;

public class QuitScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game, but you're using the game preview in Unity");
    }
}