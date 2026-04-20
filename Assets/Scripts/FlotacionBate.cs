using UnityEngine;

public class FlotacionBate : MonoBehaviour
{
    [Header("Ajustes de Rotación")]
    public float velocidadRotacion = 45f;

    [Header("Ajustes de Flotación")]
    public float alturaFlotacion = 0.1f;
    public float velocidadFlotacion = 2f;

    private Vector3 posicionInicial;
    private bool estaAgarrado = false;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!estaAgarrado)
        {
            transform.Rotate(0f, velocidadRotacion * Time.deltaTime, 0f, Space.Self);
            float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlotacion) * alturaFlotacion;
            transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
        }
    }

    public void DetenerFlotacion()
    {
        estaAgarrado = true;
    }
}