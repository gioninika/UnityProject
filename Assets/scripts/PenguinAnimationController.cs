using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class HeroNightAnimationController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpForce;
    private SpriteRenderer _rend;
    private Animator _anim;
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        var input = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * input * Time.deltaTime * speed);

        if (input > 0)
        {
            _rend.flipX = false;
            _anim.SetBool("Run", true);
        }
        else if (input == 0)
        {
            _anim.SetBool("Run", false);
        }
        else if (input < 0)
        {
            _rend.flipX = true;
            _anim.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        _anim.SetTrigger("Jump");
    }
    
}
