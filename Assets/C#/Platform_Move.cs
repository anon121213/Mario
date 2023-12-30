using Unity.VisualScripting;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{

    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private Transform _startPos;

    [SerializeField] private Vector3 _nextPos;

    [SerializeField] private float _speed = 1.0f;    

    private void Awake()
    {

        _nextPos = _startPos.position;

    }

    private void FixedUpdate()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed);

        if (transform.position == _pos1.position)
        {

            _nextPos = _pos2.position;

        }

        else if (transform.position == _pos2.position)
        {

            _nextPos = _pos1.position;

        }
       
    }

    
}
