using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashanim : MonoBehaviour
{
    private Animator animator;
    public static bool anim = false;
    AnimatorStateInfo animStateInfo;
    bool animationFinished;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (anim == true)
        {
            animator.SetBool("fx", true);
        }      
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
