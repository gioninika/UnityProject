using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PenguinAnimationController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private SpriteRenderer _rend;
    private Animator _anim;
    [SerializeField] private Transform SpawnPoint;
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        transform.position = SpawnPoint.position;
    }

    void Update()
    {
        if (UIManager.IsGamePaused)
        {
            return;
        }

        var input = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * input * Time.deltaTime * speed);

        if (input > 0)
        {
            _rend.flipX = false;
            _anim.SetBool("Run", true);
        }
        else if (input < 0)
        {
            _rend.flipX = true;
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }
}
