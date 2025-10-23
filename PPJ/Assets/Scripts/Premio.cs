using UnityEngine;

public class Premio : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Encostou: " + other.name);

        if (other.CompareTag("Player"))
        {
            GameManager.gm.UpdateScore(2);
            Destroy(gameObject);
        }
    }
}