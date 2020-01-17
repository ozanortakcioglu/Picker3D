using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {

            if (gameObject.tag == "1")
            {
                animator.SetTrigger("checkpoint"); 
            }
            else if(gameObject.tag == "2")
            {
                animator.SetTrigger("checkpoint2");
            }
        }
    }
}
