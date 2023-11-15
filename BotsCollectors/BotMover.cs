using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private DetectedResource _resources;
    [SerializeField] private GameObject _resourcesInHand;
    [SerializeField] private Transform _basket;
    [SerializeField] private float _speed;

    private GameObject _target;
    private Vector3 _startPosition;
    private bool _isTake = false;
    private int _resourcecCountInHand = 0;

    public int ResourceCountInHand => _resourcecCountInHand;

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {

        if (_isTake)
        {
            MoveToTarget(_basket.position);
        }
        else
        {
            _target = ClosesResorce();

            if (_target != null)
            {
                MoveToTarget(_target.transform.position);
            }
            else
            {

                MoveToTarget(_startPosition);
            }
        }
    }

    public void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Resource>(out Resource resource))
        {
            _isTake = true;
            _resourcesInHand.SetActive(true);
            _resourcecCountInHand = resource.ResourceUnit;
        }

        if (collision.TryGetComponent<CollectionResource>(out CollectionResource counter))
        {
            _isTake = false;
            _resourcesInHand.SetActive(false);
        }
    }

    private GameObject ClosesResorce()
    {
        GameObject closesHere = null;

        float leastDistance = Mathf.Infinity;

        for (int i = 0; i < _resources.Targets.Length; i++)
        {
            if (_resources.GetResource(i) != null)
            {
                float distanceHere = Vector3.Distance(transform.position, _resources.GetResource(i).transform.position);

                if (distanceHere < leastDistance)
                {
                    leastDistance = distanceHere;
                    closesHere = _resources.GetResource(i);
                }
            }
        }

        return closesHere;
    }
}
