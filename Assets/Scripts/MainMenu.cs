using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            AudioManager.instance.Play("MainMenuMusic");
        }
    }
    public void RunGame()
    {
        AudioManager.instance.Play("ClickSound");
        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Stop("LoseGameMusic");
        AudioManager.instance.Stop("WinGameMusic");
        GameManager.Instance.ResetScore();

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        AudioManager.instance.Play("ClickSound");
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
