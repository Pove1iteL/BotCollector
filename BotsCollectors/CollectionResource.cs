using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionResource : MonoBehaviour
{
    [SerializeField] private Text _quantityResourceVisual;

    private int _quantityResources = 0;

    private void Update()
    {
        _quantityResourceVisual.text = _quantityResources.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Resource>(out Resource resource))
        {
            _quantityResources += resource.ResourceUnit;
        }
    }
}
