using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorUI : MonoBehaviour
{ 
    private static ManejadorUI instancia;  // Instancia Singleton
    private TextMeshProUGUI textoUsuario;

    private void Awake() {
        if (instancia != null && instancia != this){
            Destroy(gameObject);
        }
        else{
            instancia = this;
            DontDestroyOnLoad(gameObject);  // Mantener el objeto en todas las escenas
        }
    }

    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        textoUsuario = GameObject.Find("TextoUsuario")?.GetComponent<TextMeshProUGUI>();
        if (textoUsuario == null) {
            Debug.LogWarning("No se encontró el componente TextMeshProUGUI para el usuario.");
        }
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Aquí podrías actualizar si la escena ha cambiado
        Scene escenaActual = SceneManager.GetActiveScene();
        // Usa la escena actual para hacer cualquier actualización
    }
}
