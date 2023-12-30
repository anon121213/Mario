using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class kakashka : MonoBehaviour
{
    [SerializeField] private GameObject Coin;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _forceDrop = 5f;

    private int _hp = 3;
    private Rigidbody2D _rb;
    private Rigidbody2D CoinRb;
    

    public bool _right_Move = true;
    
    public bool Flip = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();   
        CoinRb = Coin.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pipes")
        {
            _right_Move = !_right_Move;
        }
        else if (collision.gameObject.tag == "bulet")
        {
            _hp--;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            _right_Move = !_right_Move;
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<health>().TakeDamage(_damage);

        }
    }

    private void FixedUpdate()
    {
        /*Flip = GetComponent<chek_block>()._flip;*/
        if (_hp <= 0)
        {
            Destroy(gameObject);
            DropCoin();
        }

        if (_right_Move)
        {

            _rb.velocity = new Vector3(_speed, 0f, 0f);

        }
        else if (Flip == true)
        {

            _right_Move = !_right_Move;

        }
        else
        {

            _rb.velocity = new Vector3(- _speed, 0f, 0f);

        }

    }

    public void DropCoin()
    {
        Instantiate(Coin, transform.position, transform.rotation);
        CoinRb.AddForce(new Vector2(_forceDrop, _forceDrop), ForceMode2D.Impulse);
    }
}
