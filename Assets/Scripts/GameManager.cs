using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject newGameObject = new GameObject("GameManager");
                newGameObject.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    private bool isGameStart;
    public int playerScore { get; private set; }
    public void AddPlayerScore()
    {
        playerScore += 1;
    }

    public int ScoreToWin = 3;

    public bool IsGameStart()
    {
        return isGameStart;
    }
    public void SetGameStart()
    {
        isGameStart = true;
    }

    public void GameEnd()
    {
        AudioManager.instance.Play("GameEnd");
        isGameStart = false;
        Invoke("GameLose", 5);
    }

    //public void GamePause()
    //{
    //    IsGameStart = false;
    //    Time.timeScale = 0;
    //}

    public void GameLose()
    {
        SceneManager.LoadScene("LoseMenu");
        
        AudioManager.instance.Stop("GameMusicBackGround");
        AudioManager.instance.Stop("MainMenuMusic");

        AudioManager.instance.Play("LoseGameMusic");
    }

    public void GameWin()
    {
        SceneManager.LoadScene("WinMenu");

        AudioManager.instance.Stop("GameMusicBackGround");
        
        isGameStart = false;
        
        AudioManager.instance.Play("WinGameMusic");
    }

    public void ResetScore()
    {
        playerScore = 0;
    }

    private void Update()
    {
        if (playerScore == ScoreToWin && isGameStart)
        {
            GameWin();
        }
    }
}
