using UnityEngine;
using UnityEngine.UI;

public class PlayerBrainRot : MonoBehaviour
{
    private float maxBrainHealth = 255f;
    public float decreaseRatePerSecond = 10f;
    private float currentBrainHealth;
    public GameObject brainSprite;

    private RectTransform brainRectTransform;

    public void Start()
    {
        currentBrainHealth = maxBrainHealth;
        brainRectTransform = brainSprite.GetComponent<RectTransform>();
        UpdateBrainColor();
    }

    private void UpdateBrainColor()
    {
        float normalizedRed = currentBrainHealth / maxBrainHealth;
        brainSprite.GetComponent<Graphic>().color = new Color(normalizedRed, 63f / 255f, 83f / 255f, 1f);

        float normalizedScale = currentBrainHealth / maxBrainHealth;
        brainRectTransform.localScale = new Vector3(1f, normalizedScale, 1f);
    }

    public void DecreaseBrainHealth(float amount)
    {
        currentBrainHealth -= amount;
        currentBrainHealth = Mathf.Clamp(currentBrainHealth, 0f, maxBrainHealth);
        UpdateBrainColor();
    }
}