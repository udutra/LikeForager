using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject interactionObject;
    public GameState gameState;
    public GameObject actionCursor;
    public float interactionDistance;
    public float timeToDelete = 3f;
    public int playerEnergy = 3;
    public int playerEnergyMax = 5;

    public float distanceToSpawnResource;
    public float timeToSpawnResource;

    private void FixedUpdate() {
        if (interactionObject != null) {
            if (Vector2.Distance(CoreGame._instance.playerController.transform.position, interactionObject.transform.position) <= interactionDistance) {
                actionCursor.SetActive(true);
            }
            else {
                actionCursor.SetActive(false);
            }
        }
    }

    public void ActiveCursor(GameObject obj) {

        if (gameState != GameState.GAMEPLAY) {
            return;
        }

        interactionObject = obj;
        if (Vector2.Distance(CoreGame._instance.playerController.transform.position, interactionObject.transform.position) <= interactionDistance) {
            actionCursor.transform.position = obj.transform.position;
            actionCursor.SetActive(true);
        }
    }

    public void DisableCursor() {
        actionCursor.SetActive(false);
        interactionObject = null;
    }

    public void ObjectHit() {
        if (interactionObject == null) {
            return;
        }
        if (actionCursor.activeSelf == true) {
            interactionObject.SendMessage("OnHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Loot(Item item, Vector3 position) {
        DisableCursor();

        int dir = -1;

        for (int i = 0; i < item.lootAmount; i++) {
            GameObject loot = Instantiate(item.lootPrefab, position, transform.localRotation);
            loot.SendMessage("Active", dir, SendMessageOptions.DontRequireReceiver);
            dir *= -1;
        }
    }

    public bool IsNeedEnergy() {
        return playerEnergy < playerEnergyMax;
    }

    public void SetPlayerEnnergy(int amount) {
        playerEnergy += amount;
        if (playerEnergy > playerEnergyMax) {
            playerEnergy = playerEnergyMax;
        }
    }

    public void ChangeGameState(GameState newState) {
        gameState = newState;
        switch (gameState) {
            case GameState.GAMEPLAY:
                break;
            case GameState.INVENTORY: {

                    interactionObject = null;
                    actionCursor.SetActive(false);
                    break;
                }
            default:
                break;
        }
    }

    public bool PlayerDistance(Vector3 position) {
        float distance = Vector3.Distance(CoreGame._instance.playerController.transform.position, position);
        return distance >= distanceToSpawnResource;
    }
}