using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /// Reference to the coin's sprite renderer
    public Transform spriteRenderer;
    /// Reference to the world camera
    private Camera m_worldCamera;
    /// Reference to the sprite camera
    private Camera m_spriteCamera;
    /// Reference to the active scoreboard
    private Scoreboard m_scoreboard;

    void Start()
    {
        m_worldCamera = GameObject.FindGameObjectWithTag("WorldCamera").GetComponent<Camera>();
        m_spriteCamera = GameObject.FindGameObjectWithTag("SpriteCamera").GetComponent<Camera>();
        m_scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Scoreboard>();
    }

    void FixedUpdate()
    {
        // Convert the coin's position in the world to the viewport position
        Vector3 pos = m_worldCamera.WorldToViewportPoint(transform.position);
        // Convert the coin's viewport position to the sprite position
        Vector3 newpos = m_spriteCamera.ViewportToWorldPoint(pos);
        // Change the position and scale
        spriteRenderer.position = newpos;
        spriteRenderer.localScale = Vector3.one * 10.0f / newpos.z;
    }

    /// Called when a Collider enters this object's trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the object is a player, then remove this coin and increment coin count
        if (other.tag == "Player") {
            GameObject.Destroy(this.gameObject);
            m_scoreboard.IncrementCoinCount();
        }
    }
}
