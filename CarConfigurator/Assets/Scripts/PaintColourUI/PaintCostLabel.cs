using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;

public class PaintCostLabel : MonoBehaviour
{
    [SerializeField]
    private string labelName;
    [SerializeField]
    private int defaultPaintCost;
    [SerializeField]
    private UIDocument carConfigurator;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement rootElement = carConfigurator.rootVisualElement;
        Label paintCostInfo = rootElement.Q<Label>(labelName);
        paintCostInfo.text = generateCostString();
    }

    private string generateCostString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("(");
        builder.Append(CostElementBehaviour.GenerateCurrencyText(defaultPaintCost));
        builder.Append(" ea.)");
        return builder.ToString();
    }
}
