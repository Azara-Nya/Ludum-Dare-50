using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Menu mn;
    [SerializeField] private Animator Andy;
    public Sleeper Sz;
    private float moveInput;
    private bool facingLeft = true;
    Vector2 movement;

    void Update()
    {
        if (!Sz.IsAsleep && mn.CanPlay)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            moveInput = Input.GetAxis("Horizontal");

            if (moveInput == 0)
            {
                Andy.SetBool("IsWalk", false);
            }
            else
            {
                Andy.SetBool("IsWalk", true);
            }

            if (facingLeft && moveInput > 0)
            {
                Fliper();
            }
            else if (!facingLeft && moveInput < 0)
            {
                Fliper();
            }

            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }
    }

    void Fliper()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
