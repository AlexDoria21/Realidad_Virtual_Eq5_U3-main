using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuerzas : MonoBehaviour
{
    [SerializeField] float fuerza;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Continua
        //Ignora la masa
        //rb.AddForce(transform.right * fuerza, ForceMode.Acceleration);
        //Considera la masa
        rb.AddForce(transform.right * fuerza, ForceMode.Acceleration);



        //Instantanea
        //Ignora la masa
        //Considera la masa
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){ //Se manda a lamar una vez cada Xtiempo pode defeco es ada 0.02seg
    }
}
