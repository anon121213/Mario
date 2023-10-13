using System.Security.Cryptography.X509Certificates;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class Movie : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private float _move;
    private bool _flipRight = true;
    public Animator animator;
    private bool _jump = false;
    [SerializeField] private float _force = 3; 
    

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
}
