using UnityEngine;

public class Movie : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private float _move;
    private bool _flipRight = true;
    public Animator animator;
    private bool _jump = false;
    [SerializeField] private float _force = 3; 
    private Vector3 _respawnPoint;
    [SerializeField] private Rigidbody2D _respawnPointRb;
    private Vector2 _respawnPointPosition;
    [SerializeField] private Rigidbody2D _checkPointRb;
    private Vector2 _checkPointPosition;
    public static float a = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            _jump = true;
        }    
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            _jump = false;
        }
    }
    
    private void FixedUpdate()
    {
        _checkPointPosition = new Vector2(_checkPointRb.transform.position.x, _checkPointRb.transform.position.y);
        _respawnPointPosition = new Vector2 (_respawnPointRb.transform.position.x, _respawnPointRb.transform.position.y);
        _move = Input.GetAxis("Horizontal") * _speed;
        animator.SetFloat("_moveX", Mathf.Abs(_move));

        _rb.velocity = new Vector2(_move, _rb.velocity.y);

        if ((!_flipRight && _move > 0) || (_flipRight && _move < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
            _flipRight = !_flipRight;
        }

        if (Input.GetKey(KeyCode.Space) && (_jump == true))
        {
            _rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "KillZone")
        {
            transform.position = _respawnPointPosition;
        }
    }



}
