using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 100.0f;

    public float jumpSpeed = 200.0f;

    private Rigidbody2D m_rigidBody;

    public Animator spriteAnimator;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            int levelMask = LayerMask.GetMask("Level");
            RaycastHit2D castHit = Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, 0.01f, levelMask);
            if (castHit.collider != null) {
                Jump();
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        m_rigidBody.velocity = new Vector2(horizontal_input * runSpeed * Time.deltaTime, m_rigidBody.velocity.y);
        if (horizontal_input < -1e-5) {
            spriteRenderer.flipX = true;
        } else if (horizontal_input > 1e-5) {
            spriteRenderer.flipX = false;
        }
        if (Mathf.Abs(horizontal_input) > 1e-5) {
            spriteAnimator.SetBool("IsRunning", true);
        } else {
            spriteAnimator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x, jumpSpeed);
    }
}
