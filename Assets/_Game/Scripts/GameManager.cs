using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject LosingCanvas;
    [SerializeField] private Text countText;

    public int loseCount;

    private void Awake()
    {
        loseCount = 30;
        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }
    }

    private void FixedUpdate()
    {
        countText.text = "Move: " + loseCount;

        if (loseCount <= 0)
        {
            OnLosing();
        }
    }

    public void OnLosing ()
    {
        LosingCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TurnOFFLosing()
    {
        Time.timeScale = 1f;
    }
}
