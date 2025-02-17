using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
	Transform playerTransform;
	Vector2 targetPosition;
	public float speed = 2f;
	private float slimeGroundY;

	public float groundCheckDistance = 1f; // Distancia para detectar el suelo
	public LayerMask groundLayer; // Capa del suelo para el raycast
	public int health = 1; // Vida del slime


	void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	void Update()
	{
		slimeGroundY = transform.position.y; // Guardamos la posición Y inicial del slime
		if (playerTransform != null)
		{
			// seguimos al jugador en el eje X, mantenemos la Y fija
			targetPosition = new Vector2(playerTransform.position.x, slimeGroundY);

			// slime hacia la posición objetivo
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		}

		// Verificar la posición del slime respecto al suelo
		CheckGround();
	}

	void CheckGround()
	{
		// Lanzar un raycast hacia abajo para detectar el suelo
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

		// Si el raycast no detecta el suelo, ajustar la posición Y del slime
		if (hit.collider == null)
		{
			//  posición Y para que el slime esté sobre el suelo
			transform.position = new Vector2(transform.position.x, slimeGroundY);
		}
	}

	public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("🩸 Slime recibió daño! Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("💀 Slime eliminado!");
        Destroy(gameObject);
    }
	
	//Colisió física
	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Debug.Log("🔥 El jugador ha chocado con el slime!");
		}
	}*/
}