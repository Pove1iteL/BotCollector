using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenertionResource : MonoBehaviour
{
    [SerializeField] private Resource _resoursePrefab;
    [SerializeField] private Transform _resoursePoint;
    [SerializeField] private float _speedGeneration = 5;
    [SerializeField] private int _maxResources = 30;

    private Transform[] _resourcePoints;

    public int QuantityResource => _maxResources;

    private void Start()
    {
        _resourcePoints = new Transform[_resoursePoint.childCount];

        for (int i = 0; i < _resoursePoint.childCount; i++)
        {
            _resourcePoints[i] = _resoursePoint.GetChild(i);
        }

        StartCoroutine(GenerationResources());
    }

    private IEnumerator GenerationResources()
    {
        var waitSeconds = new WaitForSeconds(_speedGeneration);
        int countResourses = 0;

        while (countResourses <= _maxResources)
        {
            int randomPoint = Random.Range(0, _resourcePoints.Length);
            countResourses++;

            var resource = Instantiate(_resoursePrefab, _resourcePoints[randomPoint].position, Quaternion.identity);

            yield return waitSeconds;
        }
    }
}
