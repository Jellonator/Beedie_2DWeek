using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public float maximumSpeed = 100.0f;

    public float acceleration = 200.0f;

    public float rotationSpeed = 90.0f;

    private Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");
        if (vertical_input < 0.0) {
            vertical_input = vertical_input * 0.33f;
        }
        m_rigidbody.MoveRotation(m_rigidbody.rotation - horizontal_input * rotationSpeed * Time.deltaTime);
        float rad = (m_rigidbody.rotation + 90.0f) * Mathf.Deg2Rad;
        Vector2 forward = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        float currentSpeed = Vector2.Dot(m_rigidbody.velocity, forward);
        float targetSpeed = vertical_input * maximumSpeed;
        if (currentSpeed < targetSpeed) {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, currentSpeed, targetSpeed);
        } else if (currentSpeed > targetSpeed) {
            currentSpeed = Mathf.Clamp(currentSpeed - acceleration * Time.deltaTime, targetSpeed, currentSpeed);
        }
        m_rigidbody.velocity = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * currentSpeed;
    }
}
