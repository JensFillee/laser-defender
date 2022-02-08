using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Could be turned into singleton, but:
// having multiples in 1 scene doesn't break anything
// + causes more work because menu-buttons use this
// => don't bother
public class LevelManager : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", gameOverDelay));
    }

    public void QuitGame()
    {
        // Works for desktop app
        // WebGL: does nothing (can't quit out of web-embedded game)
        // Mobile: aslo add some other things before Application.Quit();
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
