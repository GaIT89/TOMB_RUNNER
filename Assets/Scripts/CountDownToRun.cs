using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownToRun : MonoBehaviour
{
    public string[] textCountDown;
    private float intervalToCount = 1.5f;
    private Text UICountDownText;

    private void Start()
    {
        AudioManager.instance.Play("GameMusicBackGround");
        StartCoroutine(LetGo());
    }
    public IEnumerator LetGo()
    {
        UICountDownText = GetComponent<Text>();
        int textDisplay = textCountDown.Length - 1;
        while (textDisplay >= 0)
        {
            UICountDownText.text = (textCountDown[textDisplay]);

            AudioManager.instance.Stop("RunSound");
            AudioManager.instance.Play("CountDownSound");

            yield return new WaitForSeconds(intervalToCount);
            textDisplay--;
        }
        AudioManager.instance.Play("Go");
        AudioManager.instance.Play("RunSound");
        
        GameManager.Instance.SetGameStart();
        UICountDownText.enabled = false;
    }
}
