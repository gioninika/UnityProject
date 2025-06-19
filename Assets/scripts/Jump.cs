using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float detectionDistance;

    private Rigidbody2D rb;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DetectGround();
        AddForceToPlayer();
        DrawRay();
    }

    private void DetectGround()
    {
        Ray ray = new Ray(transform.position, Vector2.down);
        canJump = Physics2D.Raycast(transform.position, Vector2.down, detectionDistance, 1 << 8);
    }

    private void AddForceToPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, Vector2.down * detectionDistance, Color.green);
    }
}
