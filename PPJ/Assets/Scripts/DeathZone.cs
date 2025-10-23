using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ppp"+other.gameObject.tag);
        if (other.CompareTag("Player"))
        {
            GameManager.gm.EndGame();
        }
    }
}