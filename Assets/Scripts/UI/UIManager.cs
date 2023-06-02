
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Control")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject tutorial;

    [Header("Sound")]
    [SerializeField] private AudioClip gameOverAudio;
    [SerializeField] private AudioClip victoryAudio;
    [SerializeField] private AudioClip pauseAudio;
    [SerializeField] private AudioClip restartAudio;
    [SerializeField] private AudioClip menuAudio;
    [SerializeField] private AudioClip nextAudio;

    private int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad =SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {

    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverAudio);
    }

    public void CLoseWindow()
    {
        tutorial.SetActive(false);
    }

    public void GameVictory()
    {
        victoryScreen.SetActive(true);
        SoundManager.instance.PlaySound(victoryAudio);
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        SoundManager.instance.PlaySound(pauseAudio);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        
            SceneManager.LoadScene(nextSceneLoad);
            if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
    }
   
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.instance.PlaySound(restartAudio);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
        SoundManager.instance.PlaySound(menuAudio);
    }

    public void Exit()
    {
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
    }
}

