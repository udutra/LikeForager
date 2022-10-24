using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item", order = 1)]
public class Item : ScriptableObject {
    public ItemType itemType;
    public ItemUse itemUse;
    [TextArea(1, 4)] public string itemDescription;

    public int hitAmount;
    public string itemName;
    public Sprite itemSprite;
    public GameObject lootPrefab;
    public int lootAmount;

    public bool isRecoverEnergy;
    public int EnergyAmount;

    public bool isRecoverMana;
    public int manaAmount;

    public bool isRecoverHP;
    public int HPAmount;
}