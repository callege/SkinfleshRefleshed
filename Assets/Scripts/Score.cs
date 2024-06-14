using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public void ChangeScore(int changeAmount)
    {
        score += changeAmount;

        if(score < 0) 
        {
            score = 0;
        }

        scoreText.text = "Score: " + score.ToString();
    }
}