using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    
    private int hitAmount;
    public Item item;

    private void Start() {
        hitAmount = item.hitAmount;
    }

    private void OnMouseOver() {
        CoreGame._instance.gameManager.ActiveCursor(this.gameObject);
    }

    private void OnMouseExit() {
        CoreGame._instance.gameManager.DisableCursor();
    }

    private void OnHit() {
        hitAmount--;

        if (hitAmount <= 0) {
            CoreGame._instance.gameManager.Loot(item, transform.position);
            Destroy(this.gameObject);
        }
    }
}
