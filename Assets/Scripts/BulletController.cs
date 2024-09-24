using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private float _lifeTime = 8f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,transform.position.y + _bulletSpeed,0) * Time.deltaTime;
        transform.Translate(movement);
    }
}
