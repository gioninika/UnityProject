using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float deathPoint;
    private PlayerCheckpointHandler playerCheckpointHandler;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCheckpointHandler = GetComponent<PlayerCheckpointHandler>();
    }

    void Update()
    {
        if (transform.position.y < deathPoint)
        {
            RespawnCoroutine();
        }
    }
    private IEnumerator RespawnCoroutine()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        playerCheckpointHandler.Respawn();
    }
}
