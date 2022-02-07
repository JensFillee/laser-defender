using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        // Also works (instead of [SerializeField]):
        // health = FindObjectOfType<Player>().gameObject.GetComponent<Health>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // scoreText.text = "0";

        // healthSlider.value = maxHealth;
        healthSlider.maxValue = playerHealth.GetHealth();;
        // healthSlider.minValue = 0f;
    }

    void Update()
    {
        // Adds leading 0's to score (always have 11 digits)
        scoreText.text = scoreKeeper.GetScore().ToString("00000000000");

        int currentHealth = playerHealth.GetHealth();
        healthSlider.value = currentHealth;
    }
}
