using UnityEngine;

public class BatBehavior : MonoBehaviour
{
	public int health = 1; // Vida del Murciélago

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("🩸 Bat recibió daño! Vida restante: " + health);

		if (health <= 0)
		{
			Debug.Log("💀 bat debería morir ahora!");
			Die();
		}
	}

	void Die()
	{
		Debug.Log("💀 Eliminando objeto: " + gameObject.name);
		Destroy(gameObject);
	}
}
