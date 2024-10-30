using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Practia8 : MonoBehaviour
{
    public GameObject tomado;
    public Transform plancha;
    public bool isTaken;
    public bool EstaObjetoCerca;
    public float tiempoCambioColor = 5f;
    public TextMeshProUGUI temporizadorTexto;  // Texto UI para mostrar el temporizador

    private Color[] colores = { Color.red, Color.green, Color.blue };
    private Color colorPlanchaActual;
    private Vector3 posicionInicialCubo;
    private Vector3 original_scale;
    private float tiempoRestante;
    private Transform padre;

    private void Awake()
    {
        padre = GameObject.Find("Personaje").GetComponent<Transform>();
    }

    void Start()
    {
        isTaken = false;
        EstaObjetoCerca = false;
        tiempoRestante = tiempoCambioColor;
        CambiarColorPlancha();
        ActualizarTextoTemporizador();  // Mostrar el tiempo inicial
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        ActualizarTextoTemporizador();

        if (tiempoRestante <= 0f)
        {
            CambiarColorPlancha();
            tiempoRestante = tiempoCambioColor;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isTaken && EstaObjetoCerca)
            {
                TomarObjeto();
            }
            else if (isTaken)
            {
                SoltarObjeto();
            }
        }
    }

    private void CambiarColorPlancha()
    {
        int indiceColor = Random.Range(0, colores.Length);
        colorPlanchaActual = colores[indiceColor];
        plancha.GetComponent<Renderer>().material.color = colorPlanchaActual;
    }

    private void ActualizarTextoTemporizador()
    {
        if (temporizadorTexto != null)
            temporizadorTexto.text = "Tiempo: " + Mathf.Ceil(tiempoRestante).ToString(); // Mostrar tiempo restante
    }

    private void TomarObjeto()
    {
        isTaken = true;
        if (tomado != null)
        {
            posicionInicialCubo = tomado.transform.position;
            original_scale = tomado.transform.localScale;
            tomado.transform.SetParent(padre);
            tomado.transform.position = transform.position;
            tomado.transform.rotation = transform.rotation;
            tomado.transform.localScale = transform.localScale;
            Rigidbody rb = tomado.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }

    private void SoltarObjeto()
    {
        isTaken = false;
        if (tomado != null)
        {
            tomado.transform.SetParent(null);
            Rigidbody rb = tomado.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;
            tomado.transform.localScale = original_scale;

            if (tomado.GetComponent<Renderer>().material.color == colorPlanchaActual)
            {
                Debug.Log("El color coincide.");
            }
            else
            {
                Debug.Log("Colores no coinciden.");
                tomado.transform.position = posicionInicialCubo;
                tiempoRestante = tiempoCambioColor;
            }
            tomado = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoTomable"))
        {
            EstaObjetoCerca = true;
            tomado = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoTomable"))
        {
            EstaObjetoCerca = false;
            if (!isTaken)
            {
                tomado = null;
            }
        }
    }
}
