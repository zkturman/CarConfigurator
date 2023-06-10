using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaintButtonManager : MonoBehaviour
{
    [SerializeField]
    private PaintColourData[] availableColours;
    [SerializeField]
    private string buttonFillName = "ButtonFill";
    [SerializeField]
    private ButtonEventData buttonEventData;
    
    void Start()
    {
        for (int i = 0; i < availableColours.Length; i++)
        {
            PaintColourButton button = new PaintColourButton(buttonEventData, availableColours[i]);
            button.SetButtonColour(buttonFillName);
        }
    }
}
