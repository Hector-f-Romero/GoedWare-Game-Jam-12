using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _maxSpeed = 10f;

    [Header("Shoot")]
    [SerializeField] private bool _isShooting;
    [SerializeField] private GameObject _buletGO;
    [SerializeField] private GameObject _buletSpawnGO;
    [SerializeField] private float _shootCooldown;
    private bool _canShoot = true;

    // Update is called once per frame
    void Update()
    {
       
        // Handle the player movement.
        MoveShip();

        if (Input.GetKey(KeyCode.Space) && _canShoot)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isShooting = false;
        }
    }

    private void MoveShip() {

        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xPos, yPos,0) * _speed * Time.deltaTime;
        transform.Translate(movement);
       
    }

    private IEnumerator Shoot()
    {
        Debug.Log("PIUM PIUM");
        Instantiate(_buletGO, _buletSpawnGO.transform.position, Quaternion.identity);

        _isShooting = true;
        _canShoot=false;

        yield return new WaitForSeconds(_shootCooldown);

        _canShoot = true;
    }
}
