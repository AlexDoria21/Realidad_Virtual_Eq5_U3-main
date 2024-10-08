using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_RayCast : MonoBehaviour
{
    [SerializeField] Transform jugador; //Referencia al jugador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la dirección del rayo hacia el jugador
        Vector3 direccion = jugador.position - transform.position;
        direccion = direccion.normalized;

        RaycastHit hit; // Almacena toda la info de la colisión del rayo
        if(Physics.Raycast(transform.position, transform.forward, out hit, 5f)) // Lanza el rayo
        {
            Debug.Log("Hace colisión");
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
            
            // Puedes usar esto para interactuar con el objeto que colisiona
            // hit.collider.gameObject.tag;
            // Destroy(hit.collider.gameObject);
        }
        else
        {
            // No hace colisión
            Debug.Log("No hace colisión");
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.black);
        }
    }
}
