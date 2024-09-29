using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBurguer : MonoBehaviour
{
    public float powerUpDuration = 10f;  
    public float speed = 3.0f;
    public float rotationSpeed = 100.0f;
    private Vector3 direction = Vector2.down;
    // public AudioManager audioManager;

    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;

        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager.Instance.ActivatePowerUp(powerUpDuration);

            Invader[] invaders = FindObjectsOfType<Invader>();

            // Iterar sobre todos los invaders y cambiar su sprite
            foreach (Invader invader in invaders)
            {
                invader.ChangeSprite(powerUpDuration);
            }
            // audioManager.PlayAudio(2);
            // Destruir el power-up tras recogerlo
            Destroy(gameObject);
        }
    }
}
