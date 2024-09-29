using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBulletsPowerUp : MonoBehaviour
{

    [Header("Power up logic")]
    [SerializeField] private float _powerUpDuration = 10f;
    [SerializeField] private float _speedFalling = 3.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;
    [SerializeField] private bool _isActive = false;
    private Vector3 _directionFall = Vector2.down;

    [Header("Player")]

    private BulletController _bulletController;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        PowerUpMovement();
    }

    private void PowerUpMovement()
    {
        this.transform.position += _directionFall * this._speedFalling * Time.deltaTime;
        this.transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator ActivePowerUp()
    {
        float currentTime = _powerUpDuration;
        _isActive = true;

        

        while (currentTime > 0)
        {
            Debug.Log("Tiempo restante: " + currentTime);
            yield return new WaitForSeconds(1f); // Espera 1 segundo
            currentTime--;
        }

        // Change player color to bring feedback
        SpriteRenderer childSpriteRenderer = _player.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Color originalSpriteColor = childSpriteRenderer.color;

        StartCoroutine(ChangeColorTemporarily(childSpriteRenderer, originalSpriteColor));
    }

    IEnumerator ChangeColorTemporarily(SpriteRenderer childSpriteRenderer, Color originalColor)
    {

        float duration = 0.5f;
        float elapsedTime = 0f;
        float flashSpeed = 0.05f;

        while (elapsedTime < duration)
        {
            childSpriteRenderer.color = Color.yellow;
            yield return new WaitForSeconds(flashSpeed);

            childSpriteRenderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(flashSpeed);

            elapsedTime += flashSpeed * 2;
        }



        // Deactives the power up
        _isActive = false;

        childSpriteRenderer.color = originalColor;
        _bulletController.isCurvePowerUpActive = false;
        Destroy(gameObject, 0.4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isActive == false)
        {
            GetComponent<SpriteRenderer>().enabled = false;

            PlayerController _playerController = _player.GetComponent<PlayerController>();
            _bulletController = _playerController.bulletGO.GetComponent<BulletController>();
            _bulletController.isCurvePowerUpActive = true;

            StartCoroutine(ActivePowerUp());

        }
    }
}
