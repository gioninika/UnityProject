using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject piano;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    private Rigidbody2D rb;

    void Start()
    {
        rb = piano.GetComponent<Rigidbody2D>();
        if (text1 != null)
        {
            text1.SetActive(false);
        }
        if (text2 != null)
        {
            text2.SetActive(false);
        }
        if (text3 != null)
        {
            text3.SetActive(false);
        }
        StartCoroutine(scene());
    }

    private IEnumerator scene()
    {
        yield return new WaitForSeconds(1.5f);
        text1.SetActive(true);
        yield return new WaitForSeconds(3f);
        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(3f);
        text2.SetActive(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2f);
        text3.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}