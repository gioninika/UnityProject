using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float Yposition = 0f;
    [SerializeField] private float OffsetX = 0f;
    [SerializeField] private float Offsetz = 0f;
    private Vector3 startposition;
    void Start()
    {
        startposition = transform.position;
    }
    void Update()
    {
        if (player == null) return;

        transform.position = new Vector3(player.position.x + OffsetX, startposition.y + Yposition, startposition.z + Offsetz);
    }
}
