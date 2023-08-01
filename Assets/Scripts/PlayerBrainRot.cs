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

    public int insanityThreshold = 200;
    public RectTransform borderRectTransform;

    public float insanityFOV = 50;
    private float startingFOV;
    public Camera playerCamera;

    private float startingPlayerSpeed;
    public GameObject player;

    public void Start()
    {
        startingPlayerSpeed = player.GetComponent<PlayerMovement>().speed;
        startingFOV = Camera.main.fieldOfView;
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

        UpdateFOV(); // Update the FOV smoothly
    }

    private void UpdateFOV()
    {
        if (currentBrainHealth < insanityThreshold - 50 && Camera.main.fieldOfView > insanityFOV)
        {
            // Smoothly increase FOV for a more intense effect as currentBrainHealth lowers
            float targetFOV = Camera.main.fieldOfView + 0.5f * (insanityThreshold - currentBrainHealth);
            targetFOV = Mathf.Clamp(targetFOV, insanityFOV, startingFOV); // Ensure FOV is within a specific range
            ChangeFOVSmoothly(targetFOV, 0.5f); // Adjust the duration as needed
            player.GetComponent<PlayerMovement>().speed = startingPlayerSpeed - 2f;
        }
        else if (currentBrainHealth < insanityThreshold - 50 && Camera.main.fieldOfView < insanityFOV)
        {
            // Smoothly decrease FOV to its normal state
            float targetFOV = Camera.main.fieldOfView - 0.5f * (insanityThreshold - currentBrainHealth);
            targetFOV = Mathf.Clamp(targetFOV, insanityFOV, startingFOV); // Ensure FOV is within a specific range
            ChangeFOVSmoothly(targetFOV, 0.5f); // Adjust the duration as needed
        }
        else
        {
            // Reset to the starting FOV and player speed
            ChangeFOVSmoothly(startingFOV, 0.5f); // Adjust the duration as needed
            player.GetComponent<PlayerMovement>().speed = startingPlayerSpeed;
        }
    }

    private bool isChangingFOV = false;

    private void ChangeFOVSmoothly(float targetFOV, float duration)
    {
        if (isChangingFOV) return;
        StartCoroutine(ChangeFOVRoutine(targetFOV, duration));
    }

    private IEnumerator ChangeFOVRoutine(float targetFOV, float duration)
    {
        isChangingFOV = true;
        float startFOV = Camera.main.fieldOfView;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float t = Mathf.Clamp01(timePassed / duration);
            Camera.main.fieldOfView = Mathf.Lerp(startFOV, targetFOV, t);

            yield return null;
        }

        Camera.main.fieldOfView = targetFOV;
        isChangingFOV = false;
    }


    private void UpdateBrainColorAndScale()
    {
        float normalizedRed = currentBrainHealth / maxBrainHealth;
        brainSprite.GetComponent<Graphic>().color = new Color(normalizedRed, 63f / 255f, 83f / 255f, 1f);

        float normalizedScale = currentBrainHealth / maxBrainHealth;
        brainRectTransform.localScale = new Vector3(1f, normalizedScale, 1f);

        if(currentBrainHealth < insanityThreshold)
        {
            borderRectTransform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            borderRectTransform.localScale = new Vector3(0f, 0f, 0f);
        }
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