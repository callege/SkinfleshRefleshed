using UnityEngine;

public class SoundOnTouch : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<AudioSource>().Play();
    }
}