using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textObject;

    private void Start()
    {
        if (textObject != null)
            textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && textObject != null)
        {
            textObject.SetActive(true);
        }
    }
}
