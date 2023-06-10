using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessorySelector : MonoBehaviour
{
    private AccessoryData currentAccessory;
    [SerializeField]
    private CostElementBehaviour costBehaviour;
    [SerializeField]
    private ModelSelector modelSelector;
    public void UpdateAccessory(AccessoryData accessoryData)
    {
        if (currentAccessory != accessoryData)
        {
            if (currentAccessory != null)
            {
                costBehaviour.UpdateCostText(currentAccessory.Cost * -1);
            }
            costBehaviour.UpdateCostText(accessoryData.Cost);
            modelSelector.SetWeapon(accessoryData.Prefab);
            currentAccessory = accessoryData;
        }
        else
        {
            if (currentAccessory != null)
            {
                costBehaviour.UpdateCostText(currentAccessory.Cost * -1);
            }
            currentAccessory = null;
            modelSelector.SetWeapon(null);
        }
    }
}
