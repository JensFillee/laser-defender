using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If other = an object with a DamageDealer-component
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            // This object takes damage
            TakeDamage(damageDealer.getDamage());
            
            // Play particle effect
            PlayHitEffect();

            // Damage dealer will register hit
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        // If we attached a hit effect
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // instance.main.duration = duration of particle system
            // main.startLifetime.constantMax = lifetime of particle system (because we used random between 2 constants)
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
