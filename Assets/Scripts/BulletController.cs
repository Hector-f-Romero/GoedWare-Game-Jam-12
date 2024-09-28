using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private float _lifeTime = 8f;

    [Header("Curve bullet logic")]
    public bool isCurvePowerUpActive = false;
    [SerializeField] private float _curveBulletSpeed = 5f;
    [SerializeField] private float _curveLoopSize = 1f;
    [SerializeField] private float _curveLoopSpeed = 2f;
    private float _curveTimeElapsed = 0f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }


    void Update()
    {
        if (isCurvePowerUpActive)
        {
            MoveBulletWithCurves();
            return;

        }

        // Default bullet movement.
        MoveInStraightLine();
    }

    private void MoveInStraightLine()
    {
        Vector3 movement = new Vector3(0, transform.position.y + _bulletSpeed, 0) * Time.deltaTime;
        transform.Translate(movement);
    }

    private void MoveBulletWithCurves()
    {
        // Movimiento hacia adelante
        Vector3 forwardMovement = Vector3.up * _curveBulletSpeed * Time.deltaTime;


        _curveLoopSpeed = Random.Range(-4f, 4f);
        _curveLoopSize = Random.Range(0.2f, 0.4f);

        // Movimiento en bucle usando funciones seno y coseno
        _curveTimeElapsed += Time.deltaTime * _curveLoopSpeed;
        float xMovement = Mathf.Sin(_curveTimeElapsed) * _curveLoopSize;
        float yMovement = Mathf.Cos(_curveTimeElapsed) * _curveLoopSize / 2;

        // Aplicar el movimiento con el bucle
        Vector3 loopMovement = new Vector3(xMovement, yMovement, 0);

        // Mover la bala
        transform.Translate(forwardMovement + loopMovement);
    }
}
