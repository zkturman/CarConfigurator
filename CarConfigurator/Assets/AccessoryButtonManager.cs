using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AccessoryButtonManager : MonoBehaviour
{
    [SerializeField]
    private AccessoryData[] buttonData;
    [SerializeField]
    private ButtonEventData eventData;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonData.Length; i++)
        {
            AccessoryButton button = new AccessoryButton(eventData, buttonData[i]);
        }   
    }
}
