using System.Collections;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float resetDelay = 2f;

    private Vector2 spawnPosition;
    [SerializeField] private Rigidbody2D rb;

    private bool fallStarted = false;

    void Start()
    {
        spawnPosition = transform.position;
        rb.gravityScale = 0f;  // Block stays still at the start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !fallStarted)
        {
            fallStarted = true;
            StartCoroutine(FallSequence());
        }
    }

    private IEnumerator FallSequence()
    {
        rb.gravityScale = 0f;           // Ensure block stays still
        rb.linearVelocity = Vector2.zero;     // Freeze movement
        yield return new WaitForSeconds(fallDelay);  // Wait while staying idle

        rb.gravityScale = 1f;           // After wait, start falling
        StartCoroutine(ResetBlock());
    }

    private IEnumerator ResetBlock()
    {
        yield return new WaitForSeconds(resetDelay);

        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        transform.position = spawnPosition;

        fallStarted = false;  // Allow retrigger
    }
}
