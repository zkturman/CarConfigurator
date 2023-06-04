using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject[] modelChoices;
    private GameObject currentModel;
    private int currentModelIndex = 0;
    private Color currentColour = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        if (modelChoices.Length > 0)
        {
            currentModel = Instantiate(modelChoices[0], transform);
            Renderer renderer = currentModel.GetComponent<Renderer>();
            renderer.material = new Material(renderer.material);
            renderer.material.color = currentColour;
        }
    }


}
