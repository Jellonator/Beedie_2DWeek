using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 100.0f;

    public float jumpSpeed = 200.0f;

    private Rigidbody2D m_rigidBody;

    // Start is called before the first frame update
    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        m_rigidBody.velocity = new Vector2(horizontal_input * runSpeed * Time.deltaTime, m_rigidBody.velocity.y);
    }

    void Jump()
    {
        m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, jumpSpeed);
    }
}
