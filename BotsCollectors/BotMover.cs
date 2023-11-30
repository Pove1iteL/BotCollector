using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private Transform _basket;
    [SerializeField] private float _speed;
    [SerializeField] private Base _base;

    private Vector3 _startPosition;

    private bool _hasTarget;
    private Resource _resource;
    private bool _hasResource;

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        if (_hasTarget)
        {
            if (_hasResource)
            {
                MoveToTarget(_basket.position);
            }
            else
            {
                MoveToTarget(_resource.transform.position);
            }
        }
        else
        {
            MoveToTarget(_startPosition);

            if (_base.TryGetResource(out Resource resource))
            {
                _resource = resource;
                _hasTarget = true;
            }
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Resource resource))
        {
            if (_resource == resource)
            {
                _hasResource = true;
                _resource.transform.SetParent(transform);
                _resource.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (collision.TryGetComponent(out CollectionResource collection))
        {
            if (_hasResource)
            {
                _resource.transform.SetParent(collection.transform);
                _resource.transform.position = collection.transform.position;
                collection.OnGetResource();

                _hasResource = false;
                _hasTarget = false;
                _resource.gameObject.SetActive(false);
                _resource = null;
            }
        }
    }
}