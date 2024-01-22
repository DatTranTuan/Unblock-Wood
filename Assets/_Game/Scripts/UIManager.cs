using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnReload;
    [SerializeField] private Button btnNextLevel;

    [SerializeField] private GameObject countCanvas;
    [SerializeField] private GameObject firstMap;
    [SerializeField] private GameObject secondMap;

    [SerializeField] private GameObject startGame;

    private void Start()
    {
        startGame.SetActive(true);

        btnPlay.onClick.AddListener(PressPlay);
        btnNextLevel.onClick.AddListener(NextLevel);
        btnReload.onClick.AddListener(ReloadScene);
    }

    public void PressPlay()
    {
        startGame.SetActive(false);
        countCanvas.SetActive(true);
        firstMap.SetActive(true);
    }

    public void NextLevel()
    {
        firstMap.SetActive(false);
        secondMap.SetActive(true);
        GameManager.Instance.loseCount = 35;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(CacheString.SAMPLE_SCENE);
        Time.timeScale = 1f;
    }

    public void OnCrashSaw ()
    {
        countCanvas.SetActive(false);
    }
}
