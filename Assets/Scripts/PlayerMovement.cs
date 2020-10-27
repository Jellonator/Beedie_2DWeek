using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 10.0f;

    private Rigidbody2D m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        m_rigidBody.velocity = new Vector2(horizontal_input * runSpeed * Time.deltaTime, m_rigidBody.velocity.y);
    }
}
