using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormMovement : MonoBehaviour
{
  public float horizontalMovement;
  public float moveSpeed = 4f; // Velocidad del movimiento
  public float jumpForce = 4f; // Fuerza del salto
  private bool isGrounded = false; // Verifica si el personaje está en el suelo
  private Rigidbody2D playerRigidbody; // Componente Rigidbody2D para manejar la física
  private Animator Animator;
  public GameObject bulletPrefab;  // Prefab de la bala
  public Transform firePoint;  // Punto desde donde se dispara la bala
  public float bulletSpeed = 10f;  // Velocidad de la bala


  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody2D>();
    Animator = GetComponent<Animator>();
  }

  void Update()
  {
    HandleInput();
    HandleJump();
    HandleShoot();
  }

  public void HandleInput()
  {
    horizontalMovement = Input.GetAxis("Horizontal");

    if (horizontalMovement < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    else if (horizontalMovement > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    // Cambio de animacion al desplazarse 
    Animator.SetBool("running", horizontalMovement != 0.0f);

    // Movimiento en X sin restricciones
    transform.position += new Vector3(horizontalMovement * moveSpeed * Time.deltaTime, 0, 0);
  }

  public void HandleJump()
  {
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
      isGrounded = false; // El personaje ya no está en el suelo
    }
  }

  void HandleShoot()
  {
    if (Input.GetKeyDown(KeyCode.Return))
    {
      Animator.SetBool("shoot", true);

      // Instanciar la bala
      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * bulletSpeed, 0);
    }

    if (Input.GetKeyUp(KeyCode.Return))
    {
      Animator.SetBool("shoot", false);
    }
  }

  // Detectar si el personaje está en el suelo
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isGrounded = true;
      Debug.Log("Tocando el suelo");
    }
    else if (collision.gameObject.CompareTag("Finish"))
    {
      FindAnyObjectByType<GameManager>().GameOverLose(true);
    }
  }

  // Detectar si el personaje deja de tocar el suelo
  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isGrounded = false;
      Debug.Log("Fuera del suelo");
    }
  }
}
