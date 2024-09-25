using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Invader : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector2.down;

    [SerializeField] private int _pointsToGive = 10;

    [Space(10)]
    [Header("Events")]
    public GivePointsEvent OnGivenPoints;

    private void Start()
    {
        if (OnGivenPoints == null)
        {
            Debug.Log("Evento nulo");
            OnGivenPoints = new GivePointsEvent();
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
            //Destroy(gameObject);
        }
    }
}
