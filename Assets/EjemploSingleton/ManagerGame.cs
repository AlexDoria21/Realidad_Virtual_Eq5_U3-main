using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set;}

    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject); 
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject); //this - gameobject
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            int idx_scene = SceneManager.GetActiveScene().buildIndex;
            idx_scene++;
            idx_scene %= 3; //residuo 3 porque tengo tres escenas en el entorno virtual
            changeScene(idx_scene);
        }
    }

    void changeScene(int idx){
        SceneManager.LoadScene(idx);
    }
}
