using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float jumpCooldown = 1f;
    public float attackCooldown = 1f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool grounded;
    private bool jumpLock;
    private bool attackLock;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        grounded = true;
        jumpLock = true;
        attackLock = false;
    }

    void Update() {
        
        if (!attackLock && Input.GetKeyDown(KeyCode.X)) {
            animator.SetTrigger("attack_ranged");
            attackLock = true;
            Invoke("unlockAttack", attackCooldown);
        }
        
        if (!attackLock && Input.GetKeyDown(KeyCode.Y)) {
            animator.SetTrigger("attack_close_1");
            attackLock = true;
            Invoke("unlockAttack", attackCooldown);
        }
        
        if (!attackLock && Input.GetKeyDown(KeyCode.Z)) {
            animator.SetTrigger("attack_close_2");
            attackLock = true;
            Invoke("unlockAttack", attackCooldown);
        }

    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 horiz_mov = new Vector3(moveHorizontal, 0.0f, 0.0f);
        animator.SetFloat("horiz_mov", moveHorizontal);

        if (moveHorizontal > 0) {
            transform.eulerAngles = new Vector3(0.0f, 0, 0.0f);
        }
        else if (moveHorizontal < 0) {
            transform.eulerAngles = new Vector3(0.0f, 180, 0.0f);
        }
   
        if (!attackLock)
            rb.velocity = horiz_mov * speed;

        if (grounded && moveVertical > 0) {
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Force);
            grounded = false;
            Invoke("unlockJump", jumpCooldown);
        }
    }

    void unlockJump() {
        grounded = true;
    }

    void unlockAttack() {
        attackLock = false;
    }
}
