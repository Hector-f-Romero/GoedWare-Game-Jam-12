using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] proyectil;
    [SerializeField] private float tiempoProyectiles;
    private float tiempoSiguienteProyectil;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempoSiguienteProyectil += Time.deltaTime;

        if( tiempoSiguienteProyectil >= tiempoProyectiles)
        {
            tiempoSiguienteProyectil = 0;
            CreaProyectil();
        }
    }
    void CreaProyectil()
    {
        int numeroProyectil = Random.Range(0, proyectil.Length);
        
        // Usamos siempre el punto 0 para instanciar el enemigo
        Vector2 posicionFija = puntos[0].position;

        Instantiate(proyectil[numeroProyectil], posicionFija, Quaternion.identity);
    }
}
