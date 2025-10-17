using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameObject imagemPerigoPrefab;
    public float dropInterval = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= dropInterval)
        {
            DropImage();
            timer = 0f;
        }
    }

    void DropImage()
    {
        Instantiate(imagemPerigoPrefab, transform.position, Quaternion.identity);
    }
}
