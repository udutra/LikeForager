using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSlotGrid : MonoBehaviour {
    public int line;
    public bool isBusy;
    public Collider2D col;


    public void Busy(bool value) {
        isBusy = value;

        col.enabled = !isBusy;
    }
}
