using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedResource : MonoBehaviour
{
    [SerializeField] private float detectionDelay = 1f;

    private float detectionTimer;

    [SerializeField] private List<Resource> _resources = new List<Resource>();

    private void Update()
    {
        detectionTimer -= Time.deltaTime;

        if (detectionTimer <= 0f)
        {
            DetectResources();
            detectionTimer = detectionDelay;
        }
    }

    public bool TryGetResource(out Resource resource)
    {
        if (_resources.Count == 0)
        {
            resource = null;
            return false;
        }

        var res = _resources[0];
        _resources.Remove(res);

        resource = res;

        return true;
    }

    private void DetectResources()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 100);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Resource res))
            {
                if (!_resources.Contains(res))
                {
                    if (res.IsCollected == false)
                    {
                        res.Collect();
                        _resources.Add(res);
                    }
                }
            }
        }
    }
}