using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCheckpointHandler handler = other.GetComponent<PlayerCheckpointHandler>();
            if (handler != null)
            {
                handler.SetCheckpoint(transform.position, gameObject);
            }
        }
    }
}

