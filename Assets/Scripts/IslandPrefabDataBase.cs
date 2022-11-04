using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPrefabDataBase : MonoBehaviour {
    public ResourceLoot[] resourceLV1;
    public ResourceLoot[] resourceLV2;
    public ResourceLoot[] resourceLV3;
    public ResourceLoot[] resourceLV4;
    public ResourceLoot[] resourceLV5;
    public int[] levelToupgrade;
    public List<GameObject> resourceIsland = new List<GameObject>();

    public void CreateIslandResources() {
        resourceIsland.Clear();

        for (int i = 0; i < levelToupgrade.Length; i++) {
            if (CoreGame._instance.gameManager.playerLevel >= levelToupgrade[i]) {

                switch (i) {

                    case 0: {
                            ResourceLevel(resourceLV1);
                            break;
                        }
                    case 1: {
                            ResourceLevel(resourceLV2);
                            break;
                        }
                    case 2: {
                            ResourceLevel(resourceLV3);
                            break;
                        }
                    case 3: {
                            ResourceLevel(resourceLV4);
                            break;
                        }
                    case 4: {
                            ResourceLevel(resourceLV5);
                            break;
                        }
                    default: {
                            break;
                        }
                }
            }

        }
    }

    private void ResourceLevel(ResourceLoot[] res) {
        if (res.Length > 0) {
            foreach (ResourceLoot l in res) {
                for (int i = 0; i < l.amount; i++) {
                    resourceIsland.Add(l.resource);
                }
            }
        }
    }

}
