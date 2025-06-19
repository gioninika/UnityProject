using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float detectionDistance;
    [SerializeField] private LayerMask enemyLayer;
    private Animator _anim;

    private float _direction = 1f;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateDirection();
        DrawRay();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AttackEnemy();
        }
    }

    private void UpdateDirection()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (input != 0)
        {
            _direction = input;
        }
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, Vector2.right * _direction * detectionDistance, Color.green);
    }

    public void AttackEnemy()
    {
        _anim.SetTrigger("Attack");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * _direction, detectionDistance, enemyLayer);
        if (hit.collider != null)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
