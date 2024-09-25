using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagment;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public HUD hUD;
    private int lifes = 3;
    public DeathMenu deathMenu;
    
    public void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("No joa mano, más de un GameManager");
        }
    }
    
    public void LoseLife()
    {
        lifes -= 1;
        if(lifes == 0)
        {
            deathMenu.Stop();
            Debug.Log("HasPerdido");
        }
        hUD.DeactiveLife(lifes);
    } 
}
