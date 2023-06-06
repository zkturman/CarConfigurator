using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AccessoryButton
{
    private ButtonEventData eventData;
    private AccessoryData buttonData;
    private VisualElement accessoryElement;
    private readonly string NAME_LABEL_NAME = "AccessoryName";
    private readonly string COST_LABEL_NAME = "AccessoryCost";
    private readonly string ICON_ELEMENT_NAME = "AccessoryImage";

    public AccessoryButton(ButtonEventData eventData, AccessoryData buttonData)
    {
        this.eventData = eventData;
        this.buttonData = buttonData;
        VisualElement rootElement = eventData.CarConfigurator.rootVisualElement;
        accessoryElement = rootElement.Q<VisualElement>(buttonData.ElementName);
        Label nameLabel = accessoryElement.Q<Label>(NAME_LABEL_NAME);
        nameLabel.text = buttonData.AccessoryName;
        Label costLabel = accessoryElement.Q<Label>(COST_LABEL_NAME);
        costLabel.text = CostElementBehaviour.GenerateCurrencyText(buttonData.Cost);
        VisualElement iconElement = accessoryElement.Q<VisualElement>(ICON_ELEMENT_NAME);
        iconElement.style.backgroundImage = new StyleBackground(buttonData.Icon);
        accessoryElement.RegisterCallback<MouseOverEvent>(ButtonEnterEvent);
        accessoryElement.RegisterCallback<MouseOutEvent>(ButtonExitEvent);
        accessoryElement.RegisterCallback<MouseDownEvent>(ButtonClickEvent);
        accessoryElement.RegisterCallback<MouseUpEvent>(ButtonReleaseEvent);
    }

    private void ButtonEnterEvent(MouseOverEvent evt)
    {
        accessoryElement.ToggleInClassList(eventData.HoverClassName);
        eventData.SpecManager.PreviewSpecs(buttonData.Modifier);
    }

    private void ButtonExitEvent(MouseOutEvent evt)
    {
        accessoryElement.ToggleInClassList(eventData.HoverClassName);
        accessoryElement.RemoveFromClassList(eventData.ClickClassName);
        eventData.SpecManager.RestoreSpecs();
    }

    private void ButtonClickEvent(MouseDownEvent evt)
    {
        accessoryElement.ToggleInClassList(eventData.ClickClassName);
    }

    private void ButtonReleaseEvent(MouseUpEvent evt)
    {
        accessoryElement.ToggleInClassList(eventData.ClickClassName);
        eventData.AccessorySelector.UpdateAccessory(buttonData);
        eventData.SpecManager.UpdateSpecs(buttonData.Modifier);
    }
}
