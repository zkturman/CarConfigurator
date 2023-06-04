using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaintColourButton
{
    private PaintColourData buttonData;
    private ButtonEventData eventData;
    private VisualElement colourElement;

    public PaintColourButton(ButtonEventData eventData, PaintColourData buttonData)
    {
        this.buttonData = buttonData;
        this.eventData = eventData;
        VisualElement rootElement = eventData.CarConfigurator.rootVisualElement;
        colourElement = rootElement.Q<VisualElement>(buttonData.ElementName);
        colourElement.RegisterCallback<MouseOverEvent>(ButtonEnterEvent);
        colourElement.RegisterCallback<MouseOutEvent>(ButtonExitEvent);
        colourElement.RegisterCallback<MouseDownEvent>(ButtonClickEvent);
        colourElement.RegisterCallback<MouseUpEvent>(ButtonReleaseEvent);
    }

    public void SetButtonColour(string fillElementName)
    {
        VisualElement colourFill = colourElement.Q<VisualElement>(fillElementName);
        colourFill.style.unityBackgroundImageTintColor = buttonData.PaintColour;
    }

    public void RegisterMouseOverEvent(string hoverClass)
    {
    }

    private void ButtonEnterEvent(MouseOverEvent evt)
    {
        colourElement.BringToFront();
        colourElement.ToggleInClassList(eventData.HoverClassName);
    }
    
    private void ButtonExitEvent(MouseOutEvent evt)
    {
        colourElement.ToggleInClassList(eventData.HoverClassName);
        colourElement.RemoveFromClassList(eventData.ClickClassName);
    }

    private void ButtonClickEvent(MouseDownEvent evt)
    {
        colourElement.ToggleInClassList(eventData.ClickClassName);
    }

    private void ButtonReleaseEvent(MouseUpEvent evt)
    {
        colourElement.ToggleInClassList(eventData.ClickClassName);
        eventData.ColourSelector.UpdateColour(buttonData);
    }
    
    public void RegisterMouseDownEvent(EventCallback<MouseDownEvent> eventToRegister)
    {
        colourElement.RegisterCallback(eventToRegister);
    }
}
