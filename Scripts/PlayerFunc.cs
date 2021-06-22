using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunc : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float speed, jump, distance;
    public Transform groundChecker;
    public Animator animator;
    public LayerMask GroundLayer;
    bool isGrounded;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green, distance);

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, distance, GroundLayer);

        float x = Input.GetAxis("Horizontal") * speed;
        float xRot = Input.GetAxis("Horizontal") * 10;

        transform.rotation = Quaternion.Euler(0, 0, -xRot);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rigidBody2D.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }

        if (transform.position.y < -5)
            Application.LoadLevel(Application.loadedLevel);

        if (x == 0)
            animator.SetBool("isRun", false);
        else
            animator.SetBool("isRun", true);

        if (x > 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rigidBody2D.velocity = new Vector2(x, rigidBody2D.velocity.y);
    }
}
