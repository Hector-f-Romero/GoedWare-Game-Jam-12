using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    public SceneLoader sceneLoader;
    public void Stop()
    {
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
