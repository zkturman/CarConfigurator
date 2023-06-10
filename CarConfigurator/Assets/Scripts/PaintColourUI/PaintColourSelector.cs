using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintColourSelector : MonoBehaviour
{
    [SerializeField]
    private CostElementBehaviour costBehaviour;
    [SerializeField]
    private ModelSelector modelSelector;
    private PaintColourData currentColour;
    public void UpdateColour(PaintColourData newColour)
    {
        if (currentColour != newColour)
        {
            if (currentColour != null)
            {
                costBehaviour.UpdateCostText(currentColour.Cost * -1);
            }
            costBehaviour.UpdateCostText(newColour.Cost);
            currentColour = newColour;
            modelSelector.SetModelColour(currentColour.PaintColour);
        }
        else
        {
            modelSelector.SetModelColour(Color.clear);
            if (currentColour != null)
            {
                costBehaviour.UpdateCostText(currentColour.Cost * -1);
            }
            currentColour = null;
        }
    }
}
