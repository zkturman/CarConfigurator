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
        eventData.SoundFxSource.PlayOneShot(eventData.ClickClip);
    }

    private void ButtonReleaseEvent(MouseUpEvent evt)
    {
        if (colourElement.ClassListContains(eventData.ClickClassName))
        {
            colourElement.ToggleInClassList(eventData.ClickClassName);
            eventData.ColourSelector.UpdateColour(buttonData);
            eventData.SoundFxSource.PlayOneShot(eventData.ApplyClip);
        }
    }

    public void RegisterMouseDownEvent(EventCallback<MouseDownEvent> eventToRegister)
    {
        colourElement.RegisterCallback(eventToRegister);
    }
}
