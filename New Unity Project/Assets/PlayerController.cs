using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Перемещение персонажа
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        rb.AddForce(movement, ForceMode2D.Impulse);

        rb.velocity /= 3;

        if(moveHorizontal > 0)
        {
            animator.Play("run_right_anim.cfg");
        }
        if (moveHorizontal < 0)
        {
            animator.Play("run_left_anim.cfg");
        }
        if (moveVertical > 0) 
        {
            animator.Play("run_up_anim.cfg");
        }
        if(moveVertical < 0)
        {
            animator.Play("move");
        }
        if (moveVertical == 0 && moveHorizontal == 0)
        {
            animator.Play("run_idle");
        }
    }
}