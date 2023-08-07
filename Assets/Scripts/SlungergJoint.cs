using System.Collections;
using UnityEngine;

public class SlungergJoint : MonoBehaviour
{
    private Vector3 originalPosition;
    public GameObject joint;
    public float timeToWait = 0.05f;
    public float minJiggleJump = 0.1f;
    public float maxJiggleJump = 0.5f;

    void Start()
    {
        originalPosition = joint.transform.position;
        StartCoroutine(Jiggle());
    }

    IEnumerator Jiggle()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            joint.transform.position = new Vector3(originalPosition.x + Random.Range(minJiggleJump,maxJiggleJump), originalPosition.y, originalPosition.z + Random.Range(minJiggleJump,maxJiggleJump));
            yield return new WaitForSeconds(timeToWait);
            joint.transform.position = originalPosition;
        }
    }
}