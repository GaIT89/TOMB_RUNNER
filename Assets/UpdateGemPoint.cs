using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGemPoint : MonoBehaviour
{
    private Text UigemPoint;
    private int gemPoint;

    void Start()
    {
        UigemPoint = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int gemPoint = GameManager.Instance.playerScore;
        UigemPoint.text = gemPoint.ToString();
    }
}
