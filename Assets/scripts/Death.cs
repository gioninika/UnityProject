using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float deathPoint;
    private PlayerCheckpointHandler playerCheckpointHandler;
    private bool isDead;

    void Start()
    {
        playerCheckpointHandler = GetComponent<PlayerCheckpointHandler>();
    }

    void Update()
    {
        if (transform.position.y < deathPoint && !isDead)
        {
            isDead = true;
            playerCheckpointHandler.Respawn();
            isDead = false;
            BackgroundFollow.Instance.JumpFollow();
        }
    }
}
