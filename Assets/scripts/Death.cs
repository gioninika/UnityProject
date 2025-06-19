using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float deathPoint;
    private PlayerCheckpointHandler playerCheckpointHandler;

    void Start()
    {
        playerCheckpointHandler = GetComponent<PlayerCheckpointHandler>();
    }
    void Update()
    {
        if (transform.position.y < deathPoint)
        {
            playerCheckpointHandler.Respawn();
        }
    }
}
