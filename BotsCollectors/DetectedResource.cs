using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedResource : MonoBehaviour
{
    private const string ResourseTag = "Resource";

    [SerializeField] private GenertionResource _generationResource;
    [SerializeField] private float detectionDelay = 1f;

    private float detectionTimer;
    private GameObject[] _targets;

    public GameObject[] Targets => _targets;

    private void Start()
    {
        _targets = new GameObject[_generationResource.QuantityResource];
    }

    private void Update()
    {
        detectionTimer -= Time.deltaTime;

        if (detectionTimer <= 0f)
        {
            DetectResources();
            detectionTimer = detectionDelay;
        }
    }

    public GameObject GetResource(int index)
    {
        if (index < _targets.Length && index >= 0)
        {
            return _targets[index];
        }

        return null;
    }

    private void DetectResources()
    {
        _targets = GameObject.FindGameObjectsWithTag(ResourseTag);

    }
}
