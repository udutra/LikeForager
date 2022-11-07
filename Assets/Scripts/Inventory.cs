using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private List<GameObject> inventorySlots = new();

    public Dictionary<Item, int> inventory = new();
    public GameObject inventoryPanel, slotPrefab;
    public GameObject[] subPanel;
    public int idSubPanel;
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
        InventoryTabs(0);
        bool isActive = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(isActive);

        if (isActive == true) {
            CoreGame._instance.gameManager.ChangeGameState(GameState.INVENTORY);
            UpdateInventory();
        }
        else {
            CoreGame._instance.gameManager.ChangeGameState(GameState.GAMEPLAY);
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
        itemDesc.text = item.itemDescription;
        itemUse.text = "";


        string itemCategory = "";

        switch (item.itemUse) {
            case ItemUse.MATERIAL: {
                    itemCategory = "Material";
                    break;
                }
            case ItemUse.CONSUMIVEL: {
                    itemCategory = "Consumível";
                    break;
                }
            default: { break; }
        }

        if (item.isRecoverEnergy == true) {
            itemUse.text = "Recupera <color=#FF0000>" + item.EnergyAmount.ToString() + "</color> de Energia.\n";
        }

        if (item.isRecoverMana == true) {
            itemUse.text += "Recupera <color=#FFFF00>" + item.manaAmount.ToString() + "</color> de Mana.\n";
        }

        if (item.isRecoverHP == true) {
            itemUse.text += "Recupera <color=#0000FF>" + item.HPAmount.ToString() + "</color> de HP.";
        }

        itemType.text = itemCategory;




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

            switch (item.itemUse) {
                case ItemUse.CONSUMIVEL: {
                        if (CoreGame._instance.gameManager.IsNeedEnergy() && item.isRecoverEnergy) {
                            UpdateItemInventory(item);
                            CoreGame._instance.gameManager.SetPlayerEnnergy(item.EnergyAmount);
                        }
                        break;
                    }
                case ItemUse.MATERIAL: {
                        break;
                    }
                default: {
                        break;
                    }
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

    public void InventoryTabs(int idTab) {
        foreach (GameObject t in subPanel) {
            t.SetActive(false);
        }
        subPanel[idTab].SetActive(true);
    }
}