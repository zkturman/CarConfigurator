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

    private void Start()
    {
        speedBar = new SpecificationBar(speedBarData, costConfigurator);
        handlingBar = new SpecificationBar(handlingBarData, costConfigurator);
        weightBar = new SpecificationBar(weightBarData, costConfigurator);
        attackBar = new SpecificationBar(attackBarData, costConfigurator);
        speedBar.SetDefaultValue(5);
        handlingBar.SetDefaultValue(5);
        weightBar.SetDefaultValue(5);
        attackBar.SetDefaultValue(5);
        RestoreSpecs();
    }

    public void SetDefaultValues(StatusModifier defaultValues)
    {
        speedBar.SetDefaultValue(5);
        handlingBar.SetDefaultValue(5);
        weightBar.SetDefaultValue(5);
        attackBar.SetDefaultValue(5);
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
