using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Shoot")]
    [SerializeField] private bool _isShooting;
    public GameObject bulletGO;
    [SerializeField] private GameObject _bulletSpawnGO;
    [SerializeField] private float _shootCooldown;
    private bool _canShoot = true;
    public AudioManager audioManager;

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

        Vector3 movement = new Vector3(xPos, yPos,0) * speed * Time.deltaTime;
        transform.Translate(movement);
       
    }

    private IEnumerator Shoot()
    {
        audioManager.PlaySFX(1);
        //Debug.Log("PIUM PIUM");
        Instantiate(bulletGO, _bulletSpawnGO.transform.position, Quaternion.identity);

        _isShooting = true;
        _canShoot=false;

        yield return new WaitForSeconds(_shootCooldown);

        _canShoot = true;
    }
}
