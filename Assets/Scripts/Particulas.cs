using UnityEngine;

public class Particulas : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    Vector3 playerPosition;
    Vector3 pointDirection;
    void Update()
    {
        playerPosition = new(jugador.transform.position.x-75, jugador.transform.position.y-45, jugador.transform.position.z);
        pointDirection = playerPosition - transform.position;
        transform.up = pointDirection.normalized;
    }
}
