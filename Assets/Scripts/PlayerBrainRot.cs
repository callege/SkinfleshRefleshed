using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBrainRot : MonoBehaviour
{
    private float maxBrainHealth = 255f;
    public float decreaseRatePerSecond = 5f;
    private float currentBrainHealth;
    private float originalBrainHealth;
    private bool isColliding;
    private bool isIncreasing;
    public GameObject brainSprite;

    private Coroutine increaseCoroutine;
    private RectTransform brainRectTransform;

    public void Start()
    {
        currentBrainHealth = maxBrainHealth;
        originalBrainHealth = maxBrainHealth;
        brainRectTransform = brainSprite.GetComponent<RectTransform>();
        UpdateBrainColorAndScale();
    }

    private IEnumerator IncreaseBrainHealthCoroutine()
    {
        float startTime = Time.time;
        float endTime = startTime + 4f; // 4 seconds (you can adjust this duration)

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / (endTime - startTime);
            // Decrease the rate of increase by raising t to a power (e.g., 2) between 0 and 1.
            float easedT = Mathf.Pow(t, 2f);
            currentBrainHealth = Mathf.Lerp(originalBrainHealth, maxBrainHealth, easedT);
            UpdateBrainColorAndScale();
            yield return null;
        }

        currentBrainHealth = maxBrainHealth; // Ensure the value reaches maxBrainHealth exactly
        UpdateBrainColorAndScale();
        isIncreasing = false; // Set the flag to false to stop the coroutine
    }

    public void StopIncreaseCoroutine()
    {
        if (isIncreasing && increaseCoroutine != null)
        {
            StopCoroutine(increaseCoroutine);
            isIncreasing = false;
        }
    }

    private void Update()
    {
        if (isColliding)
        {
            if (increaseCoroutine != null)
            {
                StopCoroutine(increaseCoroutine); // Stop the coroutine if there is a collision
            }
            DecreaseBrainHealth(decreaseRatePerSecond * Time.deltaTime);
        }
        else if (currentBrainHealth < maxBrainHealth && !isIncreasing)
        {
            increaseCoroutine = StartCoroutine(IncreaseBrainHealthCoroutine());
        }
    }

    private void UpdateBrainColorAndScale()
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
        UpdateBrainColorAndScale();
    }

    public void SetIsColliding(bool value)
    {
        isColliding = value;
    }
}