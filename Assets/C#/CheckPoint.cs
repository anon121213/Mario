using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject _checkPointPositionRb;
    [SerializeField] private GameObject _respawnPointPosition;
    private Vector3 _checkPointPosition;
 
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        _checkPointPosition = new Vector2(_checkPointPositionRb.transform.position.x, _checkPointPositionRb.transform.position.y);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "CheckPoint")
        {           
            _respawnPointPosition.transform.position = _checkPointPosition;
        }
    }
}
