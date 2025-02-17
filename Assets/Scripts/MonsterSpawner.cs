using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	public GameObject monsterPrefab; // Prefab del monstruo
	public Transform spawnPoint; // Posición base de la columna donde aparecerá el monstruo

	private bool monsterSpawned = false; // Evita que se genere más de una vez

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !monsterSpawned) // Si el jugador pisa la primera columna
		{
			Vector3 spawnPosition = spawnPoint.position + new Vector3(0, 0.6f, 0); // Ajuste en Y
			Instantiate(monsterPrefab, spawnPosition, Quaternion.identity); // Crear monstruo en la posición ajustada
			monsterSpawned = true; // Evita que se genere más veces
		}
	}
}
