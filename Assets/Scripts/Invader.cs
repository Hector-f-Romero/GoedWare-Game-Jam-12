using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Invader : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector2.down;
    public SpriteRenderer spriteRenderer; 
    public Sprite newSprite;
    public Vector3 newSpriteScale = new Vector3(1f, 1f, 1f);
    private Sprite originalSprite;
    private Vector3 originalScale; 

    [SerializeField] private int _pointsToGive = 10;

    [Space(10)]
    [Header("Events")]
    public GivePointsEvent OnGivenPoints;

    private void Start()
    {
        originalSprite = spriteRenderer.sprite;
        originalScale = transform.localScale;

        if (PowerUpManager.Instance != null && PowerUpManager.Instance.IsPowerUpActive())
        {
            ChangeSprite(PowerUpManager.Instance.GetPowerUpDuration());
        }
    }
    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            //Debug.Log("Trim");
            GameManager.Instance.LoseLife();
        }
        if(collider.CompareTag("Out"))
        {
            //Debug.Log("Fuera de orbita");
            Destroy(gameObject);  
        }
        if (collider.gameObject.CompareTag("Bullet"))
        {
            OnGivenPoints.Invoke(_pointsToGive);
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
    public void ChangeSprite(float duration)
    {
        spriteRenderer.sprite = newSprite;
        transform.localScale = newSpriteScale;

        StartCoroutine(ResetSpriteAfterTime(duration));
    }

    private IEnumerator ResetSpriteAfterTime(float duration)
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(duration);

        // Volver al sprite original
        spriteRenderer.sprite = originalSprite;
        transform.localScale = originalScale;
    }
}
