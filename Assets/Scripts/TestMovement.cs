using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2DPlayer;
    [SerializeField] private Transform head;
    private float speed = 50f;

    private void Start()
    {
        //rb2DPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2DPlayer.velocity = Vector2.up * speed * Time.deltaTime;
            head.rotation = Quaternion.Lerp(head.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2DPlayer.velocity = Vector2.down * speed * Time.deltaTime;
            head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2DPlayer.velocity = Vector2.left * speed * Time.deltaTime;
            head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2DPlayer.velocity = Vector2.right * speed * Time.deltaTime;
            head.rotation = Quaternion.Lerp(head.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime);
        }
    }
}
