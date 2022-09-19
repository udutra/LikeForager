using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private List<GameObject> inventorySlots = new();

    public Dictionary<Item, int> inventory = new();
    //public Dictionary<Item, GameObject> inventorySlots = new();
    public GameObject inventoryPanel, slotPrefab;
    public RectTransform slotGrid;


    public void GetItem(Item item, int amount) {
        if (inventory.ContainsKey(item)) {
            inventory[item] += amount;
        }
        else {
            inventory.Add(item, amount);
        }

        print(inventory[item]);
    }

    public void ShowInventory() {
        bool isActive = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isActive);

        if (isActive == true) {
            UpdateInventory();
        }
    }

    public void UpdateInventory() {

        foreach (GameObject s in inventorySlots) {
            Destroy(s); 
        }

        inventorySlots.Clear();

        foreach (KeyValuePair<Item, int> item in inventory) {
            GameObject i = Instantiate(slotPrefab,slotGrid);
            inventorySlots.Add(i);
            i.GetComponent<InventorySlot>().UpdateSlot(item.Key, item.Value);
        }
    }
}