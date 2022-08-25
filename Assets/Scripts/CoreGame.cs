using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGame : MonoBehaviour
{
    public static CoreGame _instance;

    public GameManager gameManager;

    private void Awake() {
        _instance = this;
    }
}
