using UnityEngine;

public class bgMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _move;

    private void FixedUpdate()
    {
        _move = Input.GetAxis("Horizontal");
        transform.Translate(_move * _speed, 0, 0);
    }
}
