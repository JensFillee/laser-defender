using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        // Loop
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            // Random.insideUnitCircle = random point inside circle with radius of 1
            // shakeMagnitude: makes this circle bigger/smaller
            // add this point to initalPosition
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        // set camera position back to initalPosition
        transform.position = initialPosition;
    }
}
