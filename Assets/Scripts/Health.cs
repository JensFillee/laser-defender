using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int scoreReward = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

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

            // Play sound effect
            audioPlayer.PlayHitSound();

            // Shake camera
            ShakeCamera();

            // Damage dealer will register hit
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreReward);
        }
        Destroy(gameObject);
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

    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            this.cameraShake.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
