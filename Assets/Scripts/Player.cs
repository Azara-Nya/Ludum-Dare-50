using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    public Sleeper Sz;
    Vector2 movement;

    void Update()
    {
        if (!Sz.IsAsleep)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }
    }
}
