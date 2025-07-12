using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PenguinAnimationController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private SpriteRenderer _rend;
    private Animator _anim;

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (UIManager.IsGamePaused)
        {
            // Don't do anything if the game is paused
            return;
        }

        var input = Input.GetAxisRaw("Horizontal");

        // Move the character
        transform.Translate(Vector2.right * input * Time.deltaTime * speed);

        // Flip and animate
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
