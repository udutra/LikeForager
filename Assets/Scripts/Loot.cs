using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Loot : MonoBehaviour {

    private float startYposition;
    private Rigidbody2D m_rigidbody;
    private Collider2D col;
    private bool isActive;
    public Item item;

    private void Update() {
        if (isActive == true && transform.position.y < startYposition - (Random.Range(0.2f, 0.6f))) {
            m_rigidbody.gravityScale = 0;
            m_rigidbody.velocity = Vector2.zero;
            isActive = false;
            col.enabled = true;
        }
    }

    private void Active(int dir) {
        m_rigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
        startYposition = transform.position.y;
        m_rigidbody.gravityScale = 1.8f;
        m_rigidbody.AddForce(Vector2.up * 250 + Vector2.right * (Random.Range(20,35) * dir));
        isActive = true;
    }
}