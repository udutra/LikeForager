using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    private GameObject interactionObject;
    public GameObject actionCursor;
    public float interactionDistance;

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
}