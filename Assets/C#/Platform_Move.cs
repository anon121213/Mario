using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{

    [SerializeField] private Transform pos1, pos2;
    [SerializeField] private Transform startPos;

    [SerializeField] private Vector3 nextPos;

    [SerializeField] private float speed = 1.0f;    

    private void Awake()
    {

        nextPos = startPos.position;

    }

    private void FixedUpdate()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed);

        if (transform.position == pos1.position)
        {

            nextPos = pos2.position;
            transform.localScale = new Vector2(-0.62f, 0.5f);

        }

        else if (transform.position == pos2.position)
        {

            nextPos = pos1.position;
            transform.localScale = new Vector2(0.62f, 0.5f);

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.parent = null;
        }
    }

}
