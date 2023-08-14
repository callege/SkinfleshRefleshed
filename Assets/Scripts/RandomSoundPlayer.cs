using System.Collections;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;
    public GameObject[] sounds;

    public void Start()
    {
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            int soundToPlay = Random.Range(0, sounds.Length);
            sounds[soundToPlay].GetComponent<AudioSource>().Play();
        }
    }
}