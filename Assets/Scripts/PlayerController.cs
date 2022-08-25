using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour{

    private Rigidbody2D m_Rigdbody;
    private Animator m_Animator;
    private Vector2 movementInput, mousePosition;
    private bool isWalk, isLookLeft;

    public float movementSpeed;

    private void Start() {
        m_Rigdbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    private void Update() {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x && isLookLeft == false) {
            Flip();
        }
        else if (mousePosition.x > transform.position.x && isLookLeft == true) {
            Flip();
        }

        if (Input.GetButtonDown("Fire1")) {
            m_Animator.SetTrigger("Axe");
        }

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isWalk = movementInput.magnitude != 0;

        m_Rigdbody.velocity = movementInput * movementSpeed;





        m_Animator.SetBool("IsWallk", isWalk);
    }


    private void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, 1, 1);
    }
}