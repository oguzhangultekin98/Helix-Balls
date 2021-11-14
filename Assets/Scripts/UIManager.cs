using Assets.Scripts.Actions.Movement;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject confetti1;
    public GameObject confetti2;
    public GameObject confetti3;

    public GameObject startPanel;
    public GameObject gamePanel; //canvas
    public GameObject gameOverPanel;
    public GameObject successPanel;

    public Text startingLevelText;
    public Text levelFailedText;
    public Text levelSuccessfulText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        startingLevelText.text = "Level " + LevelManager.instance.levelIndex;
        levelFailedText.text = "Level " + LevelManager.instance.levelIndex + " Failed";
        levelSuccessfulText.text = "Level " + (LevelManager.instance.levelIndex).ToString() + " Successful";
    }

    public void GameStart()
    {
        GameManager.instance.state = GameManager.GameState.InGame;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        FindObjectOfType<BallMovement>().Activate(Vector3.zero);
    }

    public void GameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        GameManager.instance.state = GameManager.GameState.GameOver;
    }

    public void Success()
    {
        StartCoroutine(EndingCoroutine());
        GameManager.instance.state = GameManager.GameState.GameEnded;
    }

    private IEnumerator EndingCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        confetti1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        confetti2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        confetti3.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gamePanel.SetActive(false);
        successPanel.SetActive(true);
        LevelManager.instance.UpdateLevelIndex();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Or restart level, increase playerpref index
    }
}
