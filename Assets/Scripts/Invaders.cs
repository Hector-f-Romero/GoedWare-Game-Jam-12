using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Invaders : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;

    [SerializeField] private GameObject[] poweUps;
    [SerializeField] private float tiempoPower;
    private float tiempoSiguientePower;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }
    private void Update()
    {
        
        tiempoSiguienteEnemigo += Time.deltaTime;
        tiempoSiguientePower += Time.deltaTime;

        if( tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
        if( tiempoSiguientePower >= tiempoPower)
        {
            tiempoSiguientePower = 0;
            CrearPowerUp();
        }
    }
    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
    private void CrearPowerUp()
    {
        int numeroPower = Random.Range(0, poweUps.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(poweUps[numeroPower], posicionAleatoria, Quaternion.identity);
    }
}
