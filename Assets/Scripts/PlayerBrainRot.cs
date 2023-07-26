using UnityEngine;
using UnityEngine.UI;

public class PlayerBrainRot : MonoBehaviour
{
    public float maxBrainHealth = 255f;
    //public float decreaseRate = 10f;
    public float currentBrainHealth;
    public GameObject brainSprite;

    public void Start()
    {
        currentBrainHealth = maxBrainHealth;
    }

    public void Update()
    {
        //currentBrainHealth -= decreaseRate * Time.deltaTime;
        //currentBrainHealth = Mathf.Clamp(currentBrainHealth, 0f, maxBrainHealth);

        float normalizedRed = currentBrainHealth / maxBrainHealth;
        brainSprite.GetComponent<Graphic>().color = new Color(normalizedRed, 182f / 255f, 209f / 255f, 1f);
    }
}