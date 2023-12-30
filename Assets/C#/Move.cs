using UnityEngine;

public class Movie : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private float _force = 3;
    [SerializeField] private Rigidbody2D _respawnPointRb;
    [SerializeField] private Rigidbody2D _checkPointRb;

    private float _move;

    private bool _flipRight = true;   
    private bool _jump = false; 
    
    private Vector3 _respawnPoint;   
    private Vector2 _respawnPointPosition;    
    private Vector2 _checkPointPosition;

    public Animator animator;

    private Rigidbody2D _rb;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            transform.parent = null;
        }
    }

}
