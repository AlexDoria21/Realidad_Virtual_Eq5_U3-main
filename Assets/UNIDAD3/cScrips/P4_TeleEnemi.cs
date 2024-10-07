using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P4_TeleEnemi : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    [SerializeField] Transform posicionSpawn;

    private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Player")){
        enemigo.transform.position = posicionSpawn.position;
    }
}
}
