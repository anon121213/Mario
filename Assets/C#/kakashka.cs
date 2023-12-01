using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class kakashka : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rb;
    public bool _right_Move = true;

    
    public bool Flip = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
                
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pipes")
        {
            _right_Move = !_right_Move;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            _right_Move = !_right_Move;
        }
    }

    private void FixedUpdate()
    {
        /*Flip = GetComponent<chek_block>()._flip;*/

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

}
