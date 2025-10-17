using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.gm.EndGame(); // Chama o Game Over
                Debug.Log("Jogador morto pelo inimigo fixo!");
            }
        }
    }
}