using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PenguinAnimationController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private AudioClip walkSound;  // Drag your custom sound here in Inspector
    private SpriteRenderer _rend;
    private Animator _anim;
    private AudioSource _audio;

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        transform.position = SpawnPoint.position;
        _audio.loop = true;
        _audio.clip = walkSound;      
    }

    void Update()
    {
        if (UIManager.IsGamePaused)
        {
            _audio.Stop();
            return;
        }

        var input = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * input * Time.deltaTime * speed);

        if (input > 0)
        {
            _rend.flipX = false;
            _anim.SetBool("Run", true);
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }
        else if (input < 0)
        {
            _rend.flipX = true;
            _anim.SetBool("Run", true);
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }
        else
        {
            _anim.SetBool("Run", false);
            if (_audio.isPlaying)
            {
                _audio.Stop();
            }
        }
    }
}
