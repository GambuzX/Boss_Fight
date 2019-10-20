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

    private bool defending;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        grounded = true;
        jumpLock = true;
        attackLock = false;
        defending = false;
    }

    void Update() {
        
        if (grounded && !defending && !attackLock && Input.GetButtonDown("Ranged Attack")) {
            triggerAttack("attack_ranged");
        }
        
        if (grounded && !defending && !attackLock && Input.GetButtonDown("Light Attack")) {
            triggerAttack("attack_close_1");
        }
        
        if (grounded && !defending && !attackLock && Input.GetButtonDown("Heavy Attack")) {
            triggerAttack("attack_close_2");
        }

        if (grounded && !defending && !attackLock && Input.GetButton("Guard")) {
            animator.SetTrigger("guard");
            rb.velocity = Vector3.zero;
            defending = true;
            animator.SetBool("defending", true);
        }

        if (Input.GetButtonUp("Guard")) {
            defending = false;
            animator.SetBool("defending", false);
        }

    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("horiz_mov", moveHorizontal);

        if (moveHorizontal > 0) {
            transform.eulerAngles = new Vector3(0.0f, 0, 0.0f);
        }
        else if (moveHorizontal < 0) {
            transform.eulerAngles = new Vector3(0.0f, 180, 0.0f);
        }
   
        if (!attackLock && !defending)
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        if (grounded && !defending && Input.GetButton("Jump")) {
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            Invoke("unlockJump", jumpCooldown);
        }
    }

    private void triggerAttack(string attack) {
        animator.SetTrigger(attack);
        rb.velocity = Vector3.zero;
        attackLock = true;
        Invoke("unlockAttack", attackCooldown);
    }

    void unlockJump() {
        grounded = true;
    }

    void unlockAttack() {
        attackLock = false;
    }
}
