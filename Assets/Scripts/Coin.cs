using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform spriteRenderer;

    private Camera m_worldCamera;

    private Camera m_spriteCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_worldCamera = GameObject.FindGameObjectWithTag("WorldCamera").GetComponent<Camera>();
        m_spriteCamera = GameObject.FindGameObjectWithTag("SpriteCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = m_worldCamera.WorldToViewportPoint(transform.position);
        // pos.z += 10.0f;
        Vector3 newpos = m_spriteCamera.ViewportToWorldPoint(pos);
        spriteRenderer.position = newpos;
        spriteRenderer.localScale = Vector3.one * 10.0f / newpos.z;
    }

    /// Called when a Collider enters this object's trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // check that collider is a lemoning and has not yet been found
        if (other.tag == "Player") {
            print("COIN COLLECT");
            GameObject.Destroy(this.gameObject);
        }
    }
}
