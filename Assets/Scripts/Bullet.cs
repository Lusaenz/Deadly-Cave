using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1; // Daño de la bala
    void Update()
{
    Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f);
    if (hit != null)
    {
        Debug.Log("🔥 La bala está tocando: " + hit.gameObject.name);
    }
}

     private void OnCollisionEnter2D(Collision2D collision)
      {
          Debug.Log("🔫 La bala chocó con: " + collision.gameObject.name);

          // Buscar el script del enemigo y causarle daño si lo tiene
          SlimeBehavior slime = collision.gameObject.GetComponent<SlimeBehavior>();
          BatBehavior bat = collision.gameObject.GetComponent<BatBehavior>();

          if (slime != null)
          {
              Debug.Log("💥 Impactó a un Slime!");
              slime.TakeDamage(damage);
              Destroy(gameObject); // Destruye la bala
          }
          else if (bat != null)
          {
              Debug.Log("🦇 Impactó a un Murciélago!");
              bat.TakeDamage(damage);
              Destroy(gameObject); // Destruye la bala
          }
          else
          {
              Debug.Log("❌ No impactó a un enemigo válido.");
          }
      }
 


}
