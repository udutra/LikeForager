using System.Collections;
using System.Linq;
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
        StartCoroutine(SpawnResources());
    }

    private void NewResource() {
        int idSlot = Random.Range(0, slot.Length);

        IslandSlotGrid s = slot[idSlot];

        if (!s.isBusy) {

            if (CoreGame._instance.gameManager.PlayerDistance(s.transform.position)) {
                int idResource = Random.Range(0, dataBase.resourceIsland.Count);
                GameObject resource = Instantiate(dataBase.resourceIsland[idResource]);
                resource.GetComponent<Mine>().SetSlot(s);
                s.Busy(true);
            }
        }
        else {
            NewResource();
        }
    }

    private IEnumerator SpawnResources() {

        while (true) {

            yield return new WaitForSeconds(CoreGame._instance.gameManager.timeToSpawnResource);
            int count = slot.Where(x => x.isBusy == true).Count();
            
            if (count < maxResources) {
                NewResource();
            }
        }
    }
}
