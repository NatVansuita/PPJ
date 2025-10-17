using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    // parallaxSpeed deve ser valor entre 0 e 1
    // 0 -> Sem parallax
    // 1 -> Cen�rio im�vel em rela��o � c�mera (se move junto com a c�mera)
    [Range(0f, 1f)]
    public float parallaxSpeed = 0f;

    private Transform cameraTransform;

    private float Xant; // x da c�mera no frame anterior

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.transform;
        Xant = cameraTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaCamera = cameraTransform.position.x - Xant;

        if (deltaCamera > 0)
        {
            Vector3 newPos = transform.position;
            newPos.x += parallaxSpeed * deltaCamera;
            transform.position = newPos;
        }

        Xant = cameraTransform.position.x;
    }
}