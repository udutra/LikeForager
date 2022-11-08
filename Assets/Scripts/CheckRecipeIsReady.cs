using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckRecipeIsReady : MonoBehaviour
{
    public Button button;
    public Craft recipe;

    private void Start() {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    public void CheckRecipe() {
        bool isReady = CoreGame._instance.gameManager.recipes.First(x => x.recipe == recipe).isReady;
        button.interactable = isReady;
    }
}
