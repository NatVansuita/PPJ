using UnityEngine;

namespace Platformer
{
    public class InimigoFIA : MonoBehaviour
    {
        public float chaseSpeed = 3f;
        public float chaseDuration = 3f; // quanto tempo ele corre
        public float restDuration = 2f; // quanto tempo ele descansa

        public Transform player; // arraste o jogador aqui
        private bool isChasing = false;
        private float chaseTimer = 0f;
        private float restTimer = 0f;
        private int lastScoreChecked = 0;

        void Update()
        {
            int playerScore = GameManager.gm.score; // você pode ajustar isso conforme sua lógica de pontos

            // Verifica se o jogador passou dos 5 pontos e ganhou mais desde a última vez
            if (playerScore >= 5 && playerScore > lastScoreChecked && !isChasing && restTimer <= 0f)
            {
                lastScoreChecked = playerScore;
                isChasing = true;
                chaseTimer = chaseDuration;
                Debug.Log("Inimigo começou a perseguir!");
            }

            if (isChasing)
            {
                chaseTimer -= Time.deltaTime;

                // Move na direção do jogador
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)(direction * chaseSpeed * Time.deltaTime);

                if (chaseTimer <= 0f)
                {
                    isChasing = false;
                    restTimer = restDuration;
                    Debug.Log("Inimigo parou para descansar.");
                }
            }
            else if (restTimer > 0f)
            {
                restTimer -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.gm.EndGame();
                Debug.Log("Jogador morto pelo inimigo!");
            }
        }
    }
}
