using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {

    private Rigidbody2D m_Rigdbody;
    private Animator m_Animator;
    private Vector2 movementInput, mousePosition;
    private bool isWalk, isLookLeft, isAction, isActionButton;

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

        if (Input.GetButtonDown("Fire1") && isAction == false) {
            isActionButton = true;
        }

        if (Input.GetButtonUp("Fire1")) {
            isActionButton = false;
        }

        if (isActionButton == true && isAction == false) {
            isAction = true;
            m_Animator.SetTrigger("Axe");
        }

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isWalk = movementInput.magnitude != 0;

        if (isAction == false) {
            m_Rigdbody.velocity = movementInput * movementSpeed;
        }
        else if (isAction == true) {
            m_Rigdbody.velocity = Vector2.zero;
            isWalk = false;
        }


        m_Animator.SetBool("IsWalk", isWalk);
    }

    private void Flip() {

        if (isAction == true) {
            return;
        }

        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, 1, 1);
    }

    private void ActionDone() {
        isAction = false;
    }

    public void AxeHit() {
        CoreGame._instance.gameManager.ObjectHit();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.tag) {
            case "Loot": {
                    Item item = collision.gameObject.GetComponent<Loot>().item;
                    CoreGame._instance.inventory.GetItem(item, 1);
                    Destroy(collision.gameObject);
                    break;
                }
            default: {
                    break;
                }
        }
    }
}