using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;

    public bool isFiring;

    Coroutine firingCoroutine;

    void Start()
    {

    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        // firingCoroutine == null: only have 1 firingCoroutine running at once
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            // Even after stopping firingCoroutine, it still contains something => set to null manually
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // transform.up = direction of green arrow in inspector (Vector3)
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            yield return new WaitForSecondsRealtime(firingRate);
        }
    }
}
