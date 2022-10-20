using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private List<GameObject> inventorySlots = new();

    public Dictionary<Item, int> inventory = new();
    //public Dictionary<Item, GameObject> inventorySlots = new();
    public GameObject inventoryPanel, slotPrefab;
    public RectTransform slotGrid;

    [Header("Item Onfo")]
    public GameObject itemInfoWindow;
    public Image itemImagem;
    public Text itemName, itemType, itemUse, itemDesc;

    public void GetItem(Item item, int amount) {
        if (inventory.ContainsKey(item)) {
            inventory[item] += amount;
        }
        else {
            inventory.Add(item, amount);
        }
    }

    public void ShowInventory() {
        DisableItemInfoWindow();
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
            GameObject i = Instantiate(slotPrefab, slotGrid);
            inventorySlots.Add(i);
            i.GetComponent<InventorySlot>().UpdateSlot(item.Key, item.Value);
        }
    }

    public void ShowItemInfo(Item item) {
        itemImagem.sprite = item.itemSprite;
        itemName.text = item.itemName;
        itemType.text = item.itemType.ToString();
        itemUse.text = item.itemUseTxt;
        itemDesc.text = item.itemDescription;

        itemInfoWindow.SetActive(true);
    }

    public void DisableItemInfoWindow() {
        itemInfoWindow.SetActive(false);
    }

    public void DeleteItem(Item item) {
        inventory.Remove(item);
        UpdateInventory();
        DisableItemInfoWindow();
    }

    public void UseItem(Item item) {

        if (inventory.ContainsKey(item)) {

            switch (item.itemType) {
                case ItemType.MADEIRA:
                    break;
                case ItemType.CARVAO:
                    break;
                case ItemType.FERRO:
                    break;
                case ItemType.PEDRA:
                    break;
                case ItemType.FRUTA: {
                        if (CoreGame._instance.gameManager.IsNeedEnergy()) {
                            UpdateItemInventory(item);
                            CoreGame._instance.gameManager.SetPlayerEnnergy(item.energyAmount);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private void UpdateItemInventory(Item item) {
        inventory[item] -= 1;
        if (inventory[item] <= 0) {
            DeleteItem(item);
        }
        else {
            UpdateInventory();
        }
    }
}