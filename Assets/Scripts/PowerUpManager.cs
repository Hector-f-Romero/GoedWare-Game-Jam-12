using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;  
    private bool isPowerUpActive = false;
    private float powerUpDuration = 10f;
    public AudioManager audioManager;

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia de PowerUpManager
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);  // Mantener este objeto al cargar nuevas escenas
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    // Llamado para activar el power-up globalmente
    public void ActivatePowerUp(float duration)
    {
        isPowerUpActive = true;
        powerUpDuration = duration;
        StartCoroutine(DeactivatePowerUpAfterTime(duration));
        audioManager.PlaySFX(4);
    }

    // Verificar si el power-up está activo
    public bool IsPowerUpActive()
    {
        return isPowerUpActive;
    }

    // Obtener la duración restante del power-up
    public float GetPowerUpDuration()
    {
        return powerUpDuration;
    }

    // Desactivar el power-up después del tiempo establecido
    private IEnumerator DeactivatePowerUpAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isPowerUpActive = false;
    }
}
