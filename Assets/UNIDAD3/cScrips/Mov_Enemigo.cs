using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Enemigo : MonoBehaviour
{
    Transform ubicacion_jugador;
    Distancia_Between auxDistancia;

    void Awake() {
        ubicacion_jugador = GameObject.Find("Personaje").GetComponent<Transform>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        auxDistancia  = GetComponent<Distancia_Between>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia_a_jugador = auxDistancia.distance;
        if (distancia_a_jugador<7.5f && distancia_a_jugador > 1.7f){
            float velocidad = 5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, ubicacion_jugador.position, velocidad);
        }
    }
}
