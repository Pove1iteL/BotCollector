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
        return _targets[index];
    }

    private void DetectResources()
    {
        _targets = GameObject.FindGameObjectsWithTag(ResourseTag);

        //foreach (GameObject resource in _findedResources)
        //{            
        //    _targets[index] = resource;
        //    index++;
        //}

        //index = 0;
    }
}
