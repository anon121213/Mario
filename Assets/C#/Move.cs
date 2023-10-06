using System.Security.Cryptography.X509Certificates;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class Movie : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private float _move;
    private bool _flipRight = true;

    private void FixedUpdate()
    {
        _move = Input.GetAxis("Horizontal") * _speed;
        _rb.velocity = new Vector2(_move, _rb.velocity.y);

        if (_flipRight && _move < 0)
        {
            flip();
        }
        else if (!_flipRight && _move > 0)
        {
            flip();
        }
    }

    void flip()
    {
        _flipRight = !_flipRight;
        Vector3 _scale = transform.localScale;
        _scale.x = _scale.x * (-1);
        transform.localScale = _scale;
    }
}
