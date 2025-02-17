using UnityEngine;

public class LavaFire : MonoBehaviour
{
  public float speed = 1f; // Velocidad de movimiento hacia arriba
  public float lifetime = 1f; // Tiempo antes de destruir el fuego

  void Start()
  {
    Destroy(gameObject, lifetime); //  Destruir el fuego después de un tiempo
  }

  void Update()
  {
    transform.Translate(Vector3.up * speed * Time.deltaTime); //  Movimiento hacia arriba
  }

  private void OnTriggerEnter2D(Collider2D collision) // Detectar colisión
  {
    if (collision.CompareTag("Player"))
    {
      FindAnyObjectByType<GameManager>().GameOverLose(true);
      // El jugador reciba daño y/o muere
    }
  }
}
