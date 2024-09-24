using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 direction = Vector2.down;

    private void Update()
    {
        this.transform.position += direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Fuego");
            // if (collider.GetComponent<Health>() != null)
            // {
            //     Health health = collider.GetComponent<Health>();
            //     //health.Damage(damage);
            //     health.Damage(damage);
            //     Destroy(gameObject);    
            // }
        }
        if(collider.CompareTag("Out"))
        {
            Debug.Log("Fuera de orbita");
            Destroy(gameObject);  
        }
    }
}
