using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour {
    private IslandPrefabDataBase dataBase;
    private IslandSlotGrid[] slot;
    public int initialResources, maxResources;

    private void Start() {
        dataBase = GetComponent<IslandPrefabDataBase>();
        slot = GetComponentsInChildren<IslandSlotGrid>();
        dataBase.CreateIslandResources();
        if (initialResources > 0 && dataBase.resourceIsland.Count > 0) {
            for (int i = 0; i < initialResources; i++) {
                NewResource();
            }
        }
    }

    private void NewResource() {
        int idSlot = Random.Range(0, slot.Length);

        IslandSlotGrid s = slot[idSlot];

        if (!s.isBusy) {
            int idResource = Random.Range(0, dataBase.resourceIsland.Count);
            GameObject resource = Instantiate(dataBase.resourceIsland[idResource]);
            resource.GetComponent<Mine>().SetSlot(s);
            s.Busy(true);
        }
        else {
            NewResource();
        }
    }
}
