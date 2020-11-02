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
        m_rigidbody.MoveRotation(m_rigidbody.rotation - horizontal_input * rotationSpeed * Time.deltaTime);
    }
}
