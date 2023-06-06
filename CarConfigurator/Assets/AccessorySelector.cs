using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelector : MonoBehaviour
{
    private AccessoryData currentAccessory;
    [SerializeField]
    private CostElementBehaviour costBehaviour;
    public void UpdateAccessory(AccessoryData accessoryData)
    {
        if (currentAccessory != accessoryData)
        {
            if (currentAccessory != null)
            {
                costBehaviour.UpdateCostText(currentAccessory.Cost * -1);
            }
            costBehaviour.UpdateCostText(accessoryData.Cost);
            currentAccessory = accessoryData;
        }
    }
}
