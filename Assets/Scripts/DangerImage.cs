using UnityEngine;

public class DangerImage : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -10) // Ajuste conforme a cena
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.gm.UpdateScore(-1); // Perde 1 ponto
            Destroy(gameObject);
        }
    }
}
