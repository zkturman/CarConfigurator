using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CarPaintableSurface : MonoBehaviour
{
    private Renderer surfaceRenderer;
    private Material carPaint;
    private Color originalColour;
    private void Awake()
    {
        surfaceRenderer = GetComponent<Renderer>();
        carPaint = new Material(surfaceRenderer.material);
        surfaceRenderer.material = carPaint;
        originalColour = carPaint.color;
    }

    public void UpdateColour(Color colorToApply)
    {
        carPaint.color = colorToApply;
    }

    public void RestoreOriginalPaint()
    {
        carPaint.color = originalColour;
    }
}
