using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private DetectedResource _detectedResource;

    public bool TryGetResource(out Resource resource)
    {
        if (_detectedResource.TryGetResource(out resource))
        {
            return true;
        }

        return false;
    }
}