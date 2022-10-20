using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {

    [SerializeField] private bool isDelete;
    private float deltaTime, perc;
    private Item item;
    public Image itemImage, deleteBar;
    public Text amountText;
    

    private void Update() {
        if (isDelete == true) {
            deltaTime += Time.deltaTime;
            perc = deltaTime / CoreGame._instance.gameManager.timeToDelete;
            deleteBar.fillAmount = perc;

            if (deltaTime >= CoreGame._instance.gameManager.timeToDelete) {
                CoreGame._instance.inventory.DeleteItem(item);
            }
        }
    }

    public void UpdateSlot(Item i, int amount) {
        deleteBar.gameObject.SetActive(false);
        item = i;
        itemImage.sprite = item.itemSprite;
        amountText.text = amount.ToString();
    }

    public void OnSlotClick(BaseEventData data) {
        PointerEventData pointerData = data as PointerEventData;
        if (pointerData.button == PointerEventData.InputButton.Left) {
            if (item.itemUse == ItemUse.CONSUMIVEL) {
                CoreGame._instance.inventory.UseItem(item);
            }
        }
        if (pointerData.button == PointerEventData.InputButton.Right) {
            isDelete = true;
            deltaTime = 0f;
            deleteBar.fillAmount = 0f;
            deleteBar.gameObject.SetActive(true);
}
    }

    public void MouseEnter() {
        CoreGame._instance.inventory.ShowItemInfo(item);
    }

    public void MouseExit() {
        CoreGame._instance.inventory.DisableItemInfoWindow();
        isDelete = false;
        deleteBar.gameObject.SetActive(false);
    }

    public void OnSlotUp(BaseEventData data) {
        PointerEventData pointerData = data as PointerEventData;
        if (pointerData.button == PointerEventData.InputButton.Right) {
            isDelete = false;
            deleteBar.gameObject.SetActive(false);
        }
    }
}
