using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable/Item", order = 1)]
public class Item : ScriptableObject {
    public ItemType itemType;
    public int hitAmount;
    public string itemName;
    public Sprite itemSprite;
    [TextArea(1,4)] public string itemdescription;
    public GameObject lootPrefab;
    public int lootAmount;
}