using UnityEngine;

[CreateAssetMenu(fileName = "New Craft", menuName = "Scriptable/Craft", order = 2)]
public class Craft : ScriptableObject {

    public Recipe[] recipes;
    public GameObject produce;
    public int amount;
    public float timeToProduce;
}
