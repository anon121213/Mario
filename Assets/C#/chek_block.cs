using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chek_block : MonoBehaviour
{

    public bool _flip = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _flip = true;
        }
        _flip = false;
    }
        
 
}
