using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    /// Player's maximum speed in units per second
    public float maximumSpeed = 100.0f;
    /// Player's acceleration in units per second per second.
    public float acceleration = 200.0f;
    /// Speed at which the racer will turn in degrees per second
    public float rotationSpeed = 90.0f;
    /// Reference to the world camera
    private Camera m_worldCamera;
    /// Reference to the sprite camera
    private Camera m_spriteCamera;
    /// Reference to the racer's sprite
    public Transform spriteReference;
    /// Reference to the racer's Rigidbody2D
    private Rigidbody2D m_rigidbody;
    /// Reference to the racer's sprite's Animator
    public Animator spriteAnimator;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_worldCamera = GameObject.FindGameObjectWithTag("WorldCamera").GetComponent<Camera>();
        m_spriteCamera = GameObject.FindGameObjectWithTag("SpriteCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get horizontal and vertical input
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        // Player moves slower backwards
        if (vertical_input < 0.0) {
            vertical_input = vertical_input * 0.33f;
        }
        // Player turns based on horizontal input
        m_rigidbody.MoveRotation(m_rigidbody.rotation - horizontal_input * rotationSpeed * Time.deltaTime);
        // Get the forward vector
        float rad = (m_rigidbody.rotation + 90.0f) * Mathf.Deg2Rad;
        Vector2 forward = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        // Get the player's current velocity in the forward direction
        float currentSpeed = Vector2.Dot(m_rigidbody.velocity, forward);
        // Interpolate the player's current velocity toward the target velocity.
        float targetSpeed = vertical_input * maximumSpeed;
        if (currentSpeed < targetSpeed) {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, currentSpeed, targetSpeed);
        } else if (currentSpeed > targetSpeed) {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.deltaTime, targetSpeed, currentSpeed);
        }
        // Apply velocity
        m_rigidbody.velocity = forward * currentSpeed;

        // Convert the coin's position in the world to the viewport position
        Vector3 pos = m_worldCamera.WorldToViewportPoint(transform.position);
        // Convert the coin's viewport position to the sprite position
        Vector3 newpos = m_spriteCamera.ViewportToWorldPoint(pos);
        // Change the position and scale
        spriteReference.position = newpos;
        spriteReference.localScale = Vector3.one * 10.0f / newpos.z;

        // Set the animator's speed (0.0-1.0, where 1.0 is maximum speed)
        spriteAnimator.SetFloat("Speed", currentSpeed / maximumSpeed);
    }
}
