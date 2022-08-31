using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Dictionary<Item, int> inventory = new();

    public void GetItem(Item item, int amount) {
        if (inventory.ContainsKey(item)) {
            inventory[item] += amount;
        }
        else {
            inventory.Add(item, amount);
        }

        print(inventory[item]);
    }
}