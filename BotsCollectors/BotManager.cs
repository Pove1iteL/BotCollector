using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    [SerializeField] private BotMover[] _bots;
    [SerializeField] private DetectedResource _detectedResource;
    [SerializeField] private Transform _basket;

    private Vector3 _target;
    private BotMover _currentBot;

    private void Start()
    {

    }

    private void Update()
    {
        GoToResource();

    }

    private void GoToResource()
    {        
        for (int i = 0; i < _detectedResource.Targets.Length; i++)
        {

        }

        //if (_bots[i] != null)
        //{
        //    if (_bots[i].IsTake)
        //    {
        //        i++;
        //    }
        //    else
        //    {
        //        _target = _detectedResource.Targets[i].transform.position;
        //    }
        //}
    }
}
