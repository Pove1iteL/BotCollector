using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionResource : MonoBehaviour
{
    [SerializeField] private Text _quantityResourceVisual;

    private int _quantityResources = 0;

    public void OnGetResource()
    {
        _quantityResources++;
        _quantityResourceVisual.text = _quantityResources.ToString();
    }

}