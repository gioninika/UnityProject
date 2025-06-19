using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        if (player == null) return;

        transform.position = player.position + offset;
    }
}
