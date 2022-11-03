using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    private SpriteRenderer m_SpriteRenderer;
    private float playerY;
    public float offSet;

    private void Start() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        if(m_SpriteRenderer == null) {
            return;
        }
        
        playerY = CoreGame._instance.playerController.positionY;
        if (transform.position.y < playerY - offSet) {
            m_SpriteRenderer.sortingLayerName = "PrimeiroPlano";
        }
        else {
            m_SpriteRenderer.sortingLayerName = "SegundoPlano";
        }

    }
}
