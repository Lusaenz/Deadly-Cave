using UnityEngine;

public class MosterSlime : MonoBehaviour
{
	[SerializeField] private GameObject slimePrefab;
	public Transform[] spawnPoints; // Puntos donde aparecen los slimes
	public float spawnRate = 1f;
	private float time; // Contador de tiempo
	private int randomIndex; // Índice aleatorio para los puntos de spawn
	bool canSlime = false; // Controla si aparece el slime
	public int maxSlimes = 6; // Máximo de slimes permitidos en escena
	 private int currentSlimes = 0; // Contador de slimes activos
	void Update()
    {
        if (canSlime && currentSlimes < maxSlimes)
        {
            time += Time.deltaTime;

            if (time >= spawnRate)
            {
                SpawnSlime();
                time = 0;
            }
        }
    }
	void SpawnSlime()
	{
		if (slimePrefab == null || spawnPoints.Length == 0)
		{
			Debug.LogError(" No hay prefab de slimes o los Points no está asignado.");
			return;
		}
    // Genera solo un slime por ciclo hasta alcanzar el máximo permitido
        randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;
        Instantiate(slimePrefab, spawnPosition, Quaternion.identity);
        currentSlimes++; // Incrementa el número de slimes en escena
	}

	private void OnTriggerEnter2D(Collider2D collision) // Detectar colisión
  {
    if (collision.CompareTag("Player"))
    {
      Debug.Log("a cruzado la puerta!");
      // El jugador reciba daño y/o muere
			canSlime = true;
    }
  }

}
