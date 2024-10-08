using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    float segundos;
    float cont_milisegundos;
    TextMeshProUGUI texto_contador;

    private void Awake() {
        texto_contador = GameObject.Find("Contador").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        segundos = 0;
        cont_milisegundos = 0;
    }
    // Update is called once per frame
    void Update()
    {
        cont_milisegundos += Time.deltaTime;
        if (cont_milisegundos > 1.0f){
            cont_milisegundos = 0;
            segundos++;
            texto_contador.text = segundos.ToString();
        }
    }
}
