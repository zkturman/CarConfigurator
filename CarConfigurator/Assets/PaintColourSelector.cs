using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintColourSelector : MonoBehaviour
{
    [SerializeField]
    private CostElementBehaviour costBehaviour;
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
        }
    }
}
