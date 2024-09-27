using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagment;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hUD;
    private int lifes = 3;
    public DeathMenu deathMenu;
    [SerializeField] private GameObject player;


    public void Awake()
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
        if (lifes == 0)
        {
            deathMenu.Stop();
            Debug.Log("HasPerdido");
        }

        // Change player color to bring feedback
        SpriteRenderer childSpriteRenderer = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColorTemporarily(childSpriteRenderer, childSpriteRenderer.color));

        hUD.DeactiveLife(lifes);
    }

    IEnumerator ChangeColorTemporarily(SpriteRenderer childSpriteRenderer, Color originalColor)
    {

        float duration = 1f;
        float elapsedTime = 0f;
        float flashSpeed = 0.05f;

        while (elapsedTime < duration)
        {
            childSpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashSpeed);

            childSpriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(flashSpeed);

            elapsedTime += flashSpeed * 2;
        }

        childSpriteRenderer.color = originalColor;
    }
}
