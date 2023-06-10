using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecificationBar
{
    private StatusBarData barData;
    private VisualElement specsElement;
    private VisualElement statusBarElement;
    private int baseValue = 0;
    private int currentValue = 0;
    private readonly string SPEC_LABEL_NAME = "SpecLabel";
    private readonly string STATUS_BAR_ELEMENT_NAME = "SpecStatusBar";
    private readonly string OFFICIAL_BAR_PIECE_CLASS = "status-bar-official";
    private readonly string ADDED_PREVIEW_BAR_PIECE_CLASS = "status-bar-add-preview";
    private readonly string REMOVED_PREVIEW_BAR_PIECE_CLASS = "status-bar-remove-preview";

    public SpecificationBar(StatusBarData barData, UIDocument rootDocument)
    {
        this.barData = barData;
        specsElement = rootDocument.rootVisualElement.Q<VisualElement>(barData.StatusElementName);
        Label statusLabel = specsElement.Q<Label>(SPEC_LABEL_NAME);
        statusLabel.text = barData.StatusLabel;
        statusBarElement = specsElement.Q<VisualElement>(STATUS_BAR_ELEMENT_NAME);
    }

    public void SetDefaultValue(int baseValue)
    {
        int currentBonus = currentValue - this.baseValue;
        if (baseValue < 0)
        {
            baseValue = 0;
        }
        this.baseValue = baseValue;
        currentValue = baseValue + currentBonus;
    }

    public void UpdateValue(int valueToAdd)
    {
        statusBarElement.Clear();
        currentValue = baseValue + valueToAdd;
        if (currentValue < 0)
        {
            currentValue = 0;
        }
        for (int i = 0; i < currentValue; i++)
        {
            addStatusBarPiece(OFFICIAL_BAR_PIECE_CLASS);
        }
    }

    public void PreviewValue(int previewToAdd)
    {
        string previewClass = ADDED_PREVIEW_BAR_PIECE_CLASS;
        int officialPieces = currentValue;
        int statDifference = baseValue + previewToAdd - currentValue;
        int previewPieces = Mathf.Abs(statDifference);
        if (statDifference < 0)
        {
            officialPieces = currentValue + statDifference;
            previewClass = REMOVED_PREVIEW_BAR_PIECE_CLASS;
        }
        if (officialPieces < 0)
        {
            previewPieces = officialPieces;
            officialPieces = 0;
        }
        statusBarElement.Clear();
        for (int i = 0; i < officialPieces; i++)
        {
            addStatusBarPiece(OFFICIAL_BAR_PIECE_CLASS);
        }
        for (int i = 0; i < previewPieces; i++)
        {
            addStatusBarPiece(previewClass);
        }
    }

    public void RestoreValue()
    {
        statusBarElement.Clear();
        for (int i = 0; i < currentValue; i++)
        {
            addStatusBarPiece(OFFICIAL_BAR_PIECE_CLASS);
        }
    }

    private void addStatusBarPiece(string className)
    {
        VisualElement statusBarPiece = new VisualElement();
        statusBarPiece.ToggleInClassList(className);
        statusBarElement.Add(statusBarPiece);
    }
}
