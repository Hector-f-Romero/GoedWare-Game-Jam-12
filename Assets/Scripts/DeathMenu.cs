using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    public SceneLoader sceneLoader;
    public AudioManager audioManager;

    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _playerTimeAliveText;
    public void Stop()
    {
        ScoreManager playerScore = GameObject.FindWithTag("Player").GetComponent<ScoreManager>();

        _playerScoreText.text = playerScore._playerScore.ToString();
        _playerTimeAliveText.text = playerScore._timeAlive.ToString();

        int minutes = Mathf.FloorToInt(playerScore._timeAlive / 60);
        int seconds = Mathf.FloorToInt(playerScore._timeAlive % 60);
        _playerTimeAliveText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 

        audioManager.StopMusic();
        audioManager.PlayMusic(3);
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }
    public void RestarScene()
    {
        Time.timeScale = 1f;
        sceneLoader.RestarScene();
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        sceneLoader.LoadScene("Home");
    }
    public void Quit()
    {
        sceneLoader.QuitGame();
    }
}
