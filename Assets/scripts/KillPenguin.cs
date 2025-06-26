using UnityEngine;

public class KillPenguin : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCheckpointHandler.Instance.Respawn();
        }
    }

}
