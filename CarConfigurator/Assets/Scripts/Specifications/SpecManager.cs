using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpecManager : MonoBehaviour
{
    [SerializeField]
    private StatusBarData speedBarData;
    private SpecificationBar speedBar;
    [SerializeField]
    private StatusBarData handlingBarData;
    private SpecificationBar handlingBar;
    [SerializeField]
    private StatusBarData weightBarData;
    private SpecificationBar weightBar;
    [SerializeField]
    private StatusBarData attackBarData;
    private SpecificationBar attackBar;
    [SerializeField]
    private UIDocument costConfigurator;

    private void Awake()
    {
        speedBar = new SpecificationBar(speedBarData, costConfigurator);
        handlingBar = new SpecificationBar(handlingBarData, costConfigurator);
        weightBar = new SpecificationBar(weightBarData, costConfigurator);
        attackBar = new SpecificationBar(attackBarData, costConfigurator);
        RestoreSpecs();
    }

    public void SetDefaultValues(StatusModifier defaultValues)
    {
        speedBar.SetDefaultValue(defaultValues.Speed);
        handlingBar.SetDefaultValue(defaultValues.Handling);
        weightBar.SetDefaultValue(defaultValues.Weight);
        attackBar.SetDefaultValue(defaultValues.Attack);
        RestoreSpecs();
    }

    public void PreviewSpecs(StatusModifier modifierToPreview)
    {
        speedBar.PreviewValue(modifierToPreview.Speed);
        handlingBar.PreviewValue(modifierToPreview.Handling);
        weightBar.PreviewValue(modifierToPreview.Weight);
        attackBar.PreviewValue(modifierToPreview.Attack);
    }

    public void UpdateSpecs(StatusModifier modiferToApply)
    {
        speedBar.UpdateValue(modiferToApply.Speed);
        handlingBar.UpdateValue(modiferToApply.Handling);
        weightBar.UpdateValue(modiferToApply.Weight);
        attackBar.UpdateValue(modiferToApply.Attack);
    }

    public void RestoreSpecs()
    {
        speedBar.RestoreValue();
        handlingBar.RestoreValue();
        weightBar.RestoreValue();
        attackBar.RestoreValue();
    }
}
