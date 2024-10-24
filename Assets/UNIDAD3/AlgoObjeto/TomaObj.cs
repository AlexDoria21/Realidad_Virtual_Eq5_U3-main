using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using UnityEngine;

public class TomaObj : MonoBehaviour
{
    public GameObject tomado;
    public bool isTaken;
    public bool EstaObjetoCerca;

    public Vector3 original_scale;

    Transform padre;

    private void Awake() {
        padre = GameObject.Find("Personaje").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
        EstaObjetoCerca = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
                        if(!isTaken){
                            isTaken = true;                                              
                        }
                        else{
                            isTaken = false;
                            
                        }
                    }
    }
        private void OnTriggerEnter(Collider other) {
        GameObject temporal = other.gameObject;
        if(temporal.CompareTag("ObjetoTomable")){  
            EstaObjetoCerca = true; //variable que puede ser alterada por algun evento externo
            //como podria ser una corrutina
        }
    }
        private void OnTriggerStay(Collider other) {
        GameObject temporal = other.gameObject;
        if(EstaObjetoCerca){  //si esta el objeto tomable cerca del personaje                                      
                if(isTaken){ //y presiono la tecla de tomar
                    original_scale = temporal.transform.localScale;
                    tomado = temporal;    //guardo la referencia                    
                    temporal.transform.SetParent(padre); //asocio el objeto al personaje
                    temporal.transform.position = transform.position; //el objeto se colocara en las manos del personaje                    
                    temporal.transform.rotation = transform.rotation; //el obj se coloque en la rotacion de las manos
                    temporal.transform.localScale = transform.localScale; 
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.isKinematic = true; //obj se vuelve kinematico 
                    rb.useGravity = false;
                }
                else if(tomado!=null){                                         
                    tomado = null;                    
                    temporal.transform.SetParent(null);                    
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;                    
                    tomado.transform.localScale = original_scale;                    
                }            
        }
        Debug.Log(other.gameObject.name);
    }
        private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("ObjetoTomable")){
            EstaObjetoCerca = false;
        }
        Debug.Log(other.gameObject.name);
    }
    }



