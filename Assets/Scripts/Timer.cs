using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject gameManager;
    public float totalTime;
    public float currentTime;
    public bool isRunning;

    private void Start()
    {
        currentTime = totalTime;
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isRunning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ChangeTime(int amountToChange)
    {
        currentTime += amountToChange;
    }
}