using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("InputSides", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("InputForward", Input.GetAxisRaw("Vertical"));
        animator.SetBool("Sprint", Input.GetButton("Fire3"));
        animator.SetBool("Grab", Input.GetButton("Fire2"));
        animator.SetBool("Jump", Input.GetButton("Jump"));

    }
}
