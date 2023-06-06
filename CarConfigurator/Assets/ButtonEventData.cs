using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[Serializable]
public class ButtonEventData
{
    [SerializeField]
    private string hoverClassName = "button-hover";
    public string HoverClassName { get => hoverClassName; }
    [SerializeField]
    private string clickClassName = "button-click";
    public string ClickClassName { get => clickClassName; }
    [SerializeField]
    private PaintColourSelector colourSelector;
    public PaintColourSelector ColourSelector { get => colourSelector; }
    [SerializeField]
    private AccessorySelector accessorySelector;
    public AccessorySelector AccessorySelector { get => accessorySelector; }
    [SerializeField]
    private SpecManager specManager;
    public SpecManager SpecManager { get => specManager; }
    [SerializeField]
    private UIDocument carConfigurator;
    public UIDocument CarConfigurator { get => carConfigurator; }
}
