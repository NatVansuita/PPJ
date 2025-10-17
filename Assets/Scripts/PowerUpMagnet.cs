using UnityEngine;

public class PowerUpMagnet : MonoBehaviour
{
    public float duracaoMagnet = 5f; // Tempo de dura��o do efeito im�

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o Player pegou o power-up
        {
            PlayerMagnet magnet = other.GetComponent<PlayerMagnet>();
            if (magnet != null)
            {
                magnet.AtivarMagnet(duracaoMagnet); // Ativa o efeito �m� no jogador
            }

            Destroy(gameObject); // Remove o power-up ap�s ser coletado
        }
    }
}