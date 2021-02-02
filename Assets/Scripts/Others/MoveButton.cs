using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    private readonly float moveSpeed = 1.2f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            move += Vector3.left;

        if (Input.GetKey(KeyCode.RightArrow))
            move += Vector3.right;

        if (Input.GetKey(KeyCode.UpArrow))
            move += Vector3.up;

        if (Input.GetKey(KeyCode.DownArrow))
            move += Vector3.down;

        rb.velocity = Vector3.ClampMagnitude(move, 1f) * moveSpeed;
    }
}
