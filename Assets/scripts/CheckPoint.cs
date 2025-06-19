using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCheckpointHandler checkpointHandler = other.GetComponent<PlayerCheckpointHandler>();
            if (checkpointHandler != null)
            {
                checkpointHandler.SetCheckpoint(transform.position);
            }
        }
    }
}
