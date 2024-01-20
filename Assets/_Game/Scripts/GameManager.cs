using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject LosingCanvas;

    public int loseCount = 30;

    private void FixedUpdate()
    {
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
}
