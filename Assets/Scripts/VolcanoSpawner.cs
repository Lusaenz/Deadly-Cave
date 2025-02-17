using UnityEngine;

public class VolcanoSpawner : MonoBehaviour
{
  [SerializeField] private GameObject firePrefab; // Prefab del fuego
  public Transform[] spawnPoints; // Puntos donde aparece el fuego
  public float spawnRate = 1f; // Tiempo entre cada fuego generado
  private float time; // Contador de tiempo
  private int randomIndex; // Índice aleatorio para los puntos de spawn
   bool canLava = false; // Controla si la lava aparece

  void Update()
  {
    if (canLava)
    {
      time += Time.deltaTime;

      if (time >= spawnRate)
      {
        SpawnFire();
        time = 0; // Reiniciar el tiempo
      }
    }
  }

  void SpawnFire()
  {
    if (firePrefab == null || spawnPoints.Length == 0)
    {
      Debug.LogError(" No hay prefab de fuego o spawnPoints no está asignado.");
      return;
    }

    int cantidadDeLava = 3; // generar las bolas de lava
    for (int i = 0; i < cantidadDeLava; i++)
    {
      randomIndex = Random.Range(0, spawnPoints.Length);
      Vector3 spawnPosition = spawnPoints[randomIndex].position;
      Instantiate(firePrefab, spawnPosition, Quaternion.identity);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canLava = true; // Empieza a lanzar fuego
        }
    }

}
