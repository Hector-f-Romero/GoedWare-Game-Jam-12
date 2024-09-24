using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPoints : MonoBehaviour
{

    [SerializeField] private int _pointsToGive = 10;

    [Space(10)]
    [Header("Events")]
    public GivePointsEvent OnGivenPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnGivenPoints.Invoke(_pointsToGive);
        }
    }
}
