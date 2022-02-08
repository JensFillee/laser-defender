using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // If you used 1 textfield for "you scored:" as well: 
        // scoreText.text = "You scored:\n" + scoreKeeper.GetScore();
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}
