using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Configurações de Movimento")]
        public float movingSpeed = 5f;
        public float jumpForce = 10f;

        [Header("Detecção de Chão")]
        public Transform groundCheck;
        public float groundCheckRadius = 0.2f;
        public LayerMask groundLayer;

        [Header("Outros")]
        public bool doubleJumpEnabled = true;

        private Rigidbody2D rb;
        private Animator animator;
        private bool isGrounded;
        private bool canDoubleJump;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

            if (rb == null)
            {
                Debug.LogError("Rigidbody2D não encontrado no jogador!");
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                if (rb.gravityScale == 0)
                {
                    rb.gravityScale = 1;
                }
            }
        }

        void Update()
        {
            // Movimento automático para a direita
            Vector3 direction = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);

            // Checa se está no chão
            CheckGround();

            // Entrada para pulo
            bool jumpInput = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0;

            if (jumpInput)
            {
                if (isGrounded)
                {
                    Jump();
                }
                else if (canDoubleJump && doubleJumpEnabled)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    Jump();
                    canDoubleJump = false;
                }
            }

            // 💥 Detecção de queda fatal
            if (transform.position.y < -9)
            {
                GameManager.gm.EndGame();
            }
        }

        private void Jump()
{
    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    // Marca como não está mais no chão
    isGrounded = false;

    // ⏫ Dispara a animação de pulo somente se não estiver no chão
    if (animator != null && !isGrounded)
    {
        animator.SetTrigger("Pulou");
         StartCoroutine(VoltarAnimacaoNormal());
    }
}

        private void CheckGround()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (isGrounded)
            {
                canDoubleJump = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Imã"))
    {
        if (animator != null)
        {
            animator.SetTrigger("PegouIma");
            StartCoroutine(VoltarAnimacaoNormal());
        }

        Destroy(other.gameObject);
    }
}

// Fora de qualquer outro método!
private IEnumerator VoltarAnimacaoNormal()
{
    yield return new WaitForSeconds(1.5f);
    animator.SetTrigger("VoltarNormal");
}


        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    }
}
