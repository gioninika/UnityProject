using UnityEngine;

public class PlayerCheckpointHandler : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastCheckpointPosition = transform.position;
    }

    public void SetCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpointPosition = checkpointPos;
        Debug.Log("Checkpoint set at: " + checkpointPos);
    }

    public void Respawn()
    {
        transform.position = lastCheckpointPosition;
        rb.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
