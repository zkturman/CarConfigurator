using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ModelSelector : MonoBehaviour
{
    [SerializeField]
    private ModelData[] modelChoices;
    private GameObject currentModel;
    private int currentModelIndex = 0;
    private Color currentColour = Color.white;
    [SerializeField]
    private CostElementBehaviour costBehaviour;
    private GameObject currentWeapon;
    [SerializeField]
    private ButtonEventData eventData;
    private VisualElement leftButton;
    private VisualElement rightButton;
    private Label modelName;
    private Label costInfo;
    private readonly string MODEL_ROTATOR_ELEMENT_NAME = "ModelRotator";
    private readonly string MODEL_NAME_LABEL_NAME = "ModelName";
    private readonly string MODEL_COST_LABEL_NAME = "Cost";
    private readonly string LEFT_BUTTON_NAME = "LeftButton";
    private readonly string RIGHT_BUTTON_NAME = "RightButton";
    // Start is called before the first frame update
    void Start()
    {
        currentColour = Color.clear;
        currentWeapon = null;
        setupDocumentInfo();
        if (modelChoices.Length > 0)
        {
            selectNewModel(0);
        }
    }

    private void setupDocumentInfo()
    {
        VisualElement rootElement = eventData.CarConfigurator.rootVisualElement;
        VisualElement modelInfoElement = rootElement.Q<VisualElement>(MODEL_ROTATOR_ELEMENT_NAME);
        modelName = modelInfoElement.Q<Label>(MODEL_NAME_LABEL_NAME);
        costInfo = modelInfoElement.Q<Label>(MODEL_COST_LABEL_NAME);
        leftButton = modelInfoElement.Q<VisualElement>(LEFT_BUTTON_NAME);
        leftButton.RegisterCallback<MouseUpEvent>(LeftButtonReleaseEvent);
        leftButton.RegisterCallback<MouseDownEvent>(LeftButtonClickEvent);
        leftButton.RegisterCallback<MouseOverEvent>(LeftButtonEnterEvent);
        leftButton.RegisterCallback<MouseOutEvent>(LeftButtonExitEvent);
        rightButton = modelInfoElement.Q<VisualElement>(RIGHT_BUTTON_NAME);
        rightButton.RegisterCallback<MouseUpEvent>(RightButtonReleaseEvent);
        rightButton.RegisterCallback<MouseDownEvent>(RightButtonClickEvent);
        rightButton.RegisterCallback<MouseOverEvent>(RightButtonEnterEvent);
        rightButton.RegisterCallback<MouseOutEvent>(RightButtonExitEvent);
    }

    private void LeftButtonReleaseEvent(MouseUpEvent evt)
    {
        leftButton.ToggleInClassList(eventData.ClickClassName);
        updateModelNumber(-1);
        eventData.SoundFxSource.PlayOneShot(eventData.ApplyClip);
    }

    private void RightButtonReleaseEvent(MouseUpEvent evt)
    {
        rightButton.ToggleInClassList(eventData.ClickClassName);
        updateModelNumber(1);
        eventData.SoundFxSource.PlayOneShot(eventData.ApplyClip);
    }

    private void updateModelNumber(int direction)
    {
        int newIndex = (currentModelIndex + modelChoices.Length + direction) % modelChoices.Length;
        costBehaviour.UpdateCostText(modelChoices[currentModelIndex].Cost * -1);
        Destroy(currentModel);
        selectNewModel(newIndex);
    }

    private void selectNewModel(int modelIndex)
    {
        currentModelIndex = modelIndex;
        currentModel = Instantiate(modelChoices[modelIndex].Prefab, transform);
        modelName.text = modelChoices[modelIndex].Name;
        costInfo.text = CostElementBehaviour.GenerateCurrencyText(modelChoices[modelIndex].Cost);
        costBehaviour.UpdateCostText(modelChoices[modelIndex].Cost);
        eventData.SpecManager.SetDefaultValues(modelChoices[modelIndex].BaseStats);
        SetModelColour(currentColour);
        SetWeapon(currentWeapon);
    }

    private void LeftButtonClickEvent(MouseDownEvent evt)
    {
        leftButton.ToggleInClassList(eventData.ClickClassName);
        eventData.SoundFxSource.PlayOneShot(eventData.ClickClip);
    }

    private void RightButtonClickEvent(MouseDownEvent evt)
    {
        rightButton.ToggleInClassList(eventData.ClickClassName);
        eventData.SoundFxSource.PlayOneShot(eventData.ClickClip);
    }

    private void LeftButtonEnterEvent(MouseOverEvent evt)
    {
        leftButton.ToggleInClassList(eventData.HoverClassName);
    }

    private void RightButtonEnterEvent(MouseOverEvent evt)
    {
        rightButton.ToggleInClassList(eventData.HoverClassName);
    }

    private void LeftButtonExitEvent(MouseOutEvent evt)
    {
        leftButton.ToggleInClassList(eventData.HoverClassName);
    }

    private void RightButtonExitEvent(MouseOutEvent evt)
    {
        rightButton.ToggleInClassList(eventData.HoverClassName);
    }

    public void SetModelColour(Color colourToSet)
    {
        CarPaintApplicator carPainter = currentModel.GetComponent<CarPaintApplicator>();
        currentColour = colourToSet;
        if (colourToSet == Color.clear)
        {
            carPainter.ResetPaint();
        }
        else
        {
            carPainter.PaintCar(colourToSet);
        }
    }

    public void SetWeapon(GameObject weaponPrefab)
    {
        WeaponApplicator weaponAdder = currentModel.GetComponent<WeaponApplicator>();
        currentWeapon = weaponPrefab;
        if (weaponPrefab == null)
        {
            weaponAdder.RemoveWeapon();
        }
        else
        {
            weaponAdder.AddWeapon(weaponPrefab);
        }
    }
}