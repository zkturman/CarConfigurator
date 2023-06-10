using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CarPaintApplicator : MonoBehaviour
{
    [SerializeField]
    private CarPaintableSurface[] paintSurfaces;
    private void Awake()
    {
        paintSurfaces = GetComponentsInChildren<CarPaintableSurface>();
    }
    
    public void PaintCar(Color colourToPaint)
    {
        for (int i = 0; i < paintSurfaces.Length; i++)
        {
            paintSurfaces[i].UpdateColour(colourToPaint);
        }
    }

    public void ResetPaint()
    {
        for (int i = 0; i < paintSurfaces.Length; i++)
        {
            paintSurfaces[i].RestoreOriginalPaint();
        }
    }
}
