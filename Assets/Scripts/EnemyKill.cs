using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Mata o jogador instantaneamente
            GameManager.gm.EndGame(); // Zera a vida
        }
    }
}
