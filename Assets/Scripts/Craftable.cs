using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftable : MonoBehaviour {
    public GameObject[] craftItemList;

    public void Craftar(int idItemCraft) { 
        CoreGame._instance.gameManager.StartCraftMode(craftItemList[idItemCraft]);
    }
}
