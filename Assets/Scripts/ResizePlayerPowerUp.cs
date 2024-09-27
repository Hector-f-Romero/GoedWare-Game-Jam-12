using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePlayerPowerUp : MonoBehaviour
{
    [Header("Power up logic")]
    [SerializeField] private float _powerUpDuration = 10f;
    [SerializeField] private float _speedFalling = 3.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;
    [SerializeField] private bool _isActive = false;

    [Header("Player")]
    [SerializeField] private float _minPlayerScale = 0.5f;
    [SerializeField] private float _maxPlayerScale = 2.75f;
    [SerializeField] private bool _isScalingUp = false;
    [SerializeField] private float _defaultPlayerSpeed;
    private PlayerController _playerController;


    private Vector3 direction = Vector2.down;
    

    private GameObject _player;
    private Vector3 _originalScale;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _originalScale = _player.transform.localScale;
        _playerController = _player.GetComponent<PlayerController>();
        _defaultPlayerSpeed = _playerController.speed;
    }

    private void Update()
    {
        //PowerUpMovement();
    }

    private void PowerUpMovement()
    {
        this.transform.position += direction * this._speedFalling * Time.deltaTime;
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
        StartCoroutine(ChangeColorTemporarily(childSpriteRenderer, childSpriteRenderer.color));
    }

    private IEnumerator ResizePlayerRoutine()
    {
        while (_isActive)
        {
            ResizePlayer();
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void ResizePlayer()
    {
        Vector3 newScale;
        float scaleFactor = Random.Range(0.125f, 0.5f);

        if(!_isScalingUp ) {

            if(_player.transform.localScale.x > _minPlayerScale)
            {
                newScale = new Vector3(_player.transform.localScale.x - scaleFactor, _player.transform.localScale.y - scaleFactor, _player.transform.localScale.z);
                _player.transform.localScale = newScale;

                
            }
            else
            {
                _isScalingUp = true;
            }

        }
        else
        {
            if (_player.transform.localScale.x < _maxPlayerScale)
            {
                newScale = new Vector3(_player.transform.localScale.x + scaleFactor, _player.transform.localScale.y + scaleFactor, _player.transform.localScale.z);
                _player.transform.localScale = newScale;


            }
            else
            {
                _isScalingUp = false;
            }
        }
        _playerController.speed += 0.35f;
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

        childSpriteRenderer.color = originalColor;

        // Resart the player size.
        _player.transform.localScale = _originalScale;
        _player.GetComponent<PlayerController>().speed = _defaultPlayerSpeed;

        // Deactives the power up
        _isActive = false;
        Destroy(gameObject, 0.4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isActive == false)
        {
            //PowerUpManager.Instance.ActivatePowerUp(_powerUpDuration);
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(ActivePowerUp());
            StartCoroutine(ResizePlayerRoutine());

        }
    }

   
}
