using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    private Item item;
    public Image itemImage;
    public Text amountText;

    public void UpdateSlot(Item i, int amount) {
        item = i;
        itemImage.sprite = item.itemSprite;
        amountText.text = amount.ToString();
    }

    public void OnSlotClick() {

    }

    public void MouseEnter() {
        CoreGame._instance.inventory.ShowItemInfo(item);
    }

    public void MouseExit() {
        CoreGame._instance.inventory.DisableItemInfoWindow();
    }
}
