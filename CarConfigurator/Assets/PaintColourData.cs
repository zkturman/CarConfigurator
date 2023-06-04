using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PaintColourData
{
    [SerializeField]
    private Color paintColour = Color.white;
    public Color PaintColour { get => paintColour; }
    [SerializeField]
    private string elementName = "ColourButton1";
    public string ElementName { get => elementName; }
    [SerializeField]
    private int cost = 0;
    public int Cost { get => cost; }
}
