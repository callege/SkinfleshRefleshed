using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBrainRot : MonoBehaviour
{
    private float maxBrainHealth = 255f;
    public float decreaseRatePerSecond = 5f;
    private float currentBrainHealth;
    private bool isColliding;
    private bool isIncreasing;
    public GameObject brainSprite;

    private Coroutine increaseCoroutine;
    private RectTransform brainRectTransform;

    private float targetBrainHealth;
    private float regenerationDuration = 4f;

    public void Start()
    {
        currentBrainHealth = maxBrainHealth;
        brainRectTransform = brainSprite.GetComponent<RectTransform>();
        UpdateBrainColorAndScale();
    }

    private IEnumerator IncreaseBrainHealthCoroutine(float targetHealth)
    {
        isIncreasing = true;
        float startTime = Time.time;
        float endTime = startTime + regenerationDuration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / regenerationDuration;
            float easedT = Mathf.Pow(t, 2f);
            currentBrainHealth = Mathf.Lerp(targetHealth, maxBrainHealth, easedT);
            UpdateBrainColorAndScale();
            yield return null;
        }

        currentBrainHealth = maxBrainHealth;
        UpdateBrainColorAndScale();
        isIncreasing = false;
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
                StopCoroutine(increaseCoroutine);
            }
            DecreaseBrainHealth(decreaseRatePerSecond * Time.deltaTime);
        }
        else if (currentBrainHealth < maxBrainHealth && !isIncreasing)
        {
            targetBrainHealth = currentBrainHealth;
            increaseCoroutine = StartCoroutine(IncreaseBrainHealthCoroutine(targetBrainHealth));
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