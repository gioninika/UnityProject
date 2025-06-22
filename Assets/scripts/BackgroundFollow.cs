using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset = 0f;
    [SerializeField] private float smoothSpeed = 5f;
    private Vector2 startPosition;
    private bool snappedAtStart = false;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        float targetX = player.position.x + offset;
        if (!snappedAtStart)
        {
            transform.position = new Vector2(targetX, startPosition.y);
            snappedAtStart = true;
        }
        else
        {
            float newX = Mathf.Lerp(transform.position.x, targetX, smoothSpeed * Time.deltaTime);
            transform.position = new Vector2(newX, startPosition.y);
        }
    }
}
