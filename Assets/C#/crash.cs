using UnityEngine;

public class crash : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "head")
        {
            gameObject.SetActive(false);
            crashanim.anim = true;
        }     
    }
}
