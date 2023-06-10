using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;

public class CostElementBehaviour : MonoBehaviour
{
    [SerializeField]
    private char currencySymbol;
    private static char currencySymbolConstant = '£';
    [SerializeField]
    private string currencyPrefix = "Cost";
    [SerializeField]
    private UIDocument configuratorUi;
    private int currentCost = 0;
    private Label costLabel;
    private StringBuilder textMaker = new StringBuilder();

    void Start()
    {
        VisualElement rootVisualElement = configuratorUi.rootVisualElement;
        costLabel = rootVisualElement.Q<Label>("CostLabel");
        costLabel.text = generateCostText();
        currencySymbolConstant = currencySymbol;
    }

    private string generateCostText()
    {
        textMaker.Clear();
        textMaker.Append(currencyPrefix);
        textMaker.Append(": ");
        textMaker.Append(currencySymbol);
        textMaker.Append(currentCost.ToString());
        return textMaker.ToString();
    }

    public void UpdateCostText(int valueToAdd)
    {
        currentCost += valueToAdd;
        costLabel.text = generateCostText();
    }

    public static string GenerateCurrencyText(int value)
    {
        return currencySymbolConstant + value.ToString();
    }
}
