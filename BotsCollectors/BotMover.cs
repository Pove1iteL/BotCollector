using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private DetectedResource _resources;
    [SerializeField] private Transform _basket;
    [SerializeField] private float _speed;
    [SerializeField] Base _base;

    private Vector3 _startPosition;
    private bool _isTake = false;
    private bool _isBusy = false;

    public bool IsTake => _isTake;
    public bool IsBusy => _isBusy;

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        if (_base.Detected)
        {
            if (_isTake)
            {
                MoveToTarget(_basket.position);
            }
            else
            {
                _base.BotMoveToResource();
            }

            if (transform.position.x == _basket.position.x)
            {
                _base.ChangeDetectedFalse();
                _isTake = false;
            }

            _isBusy = true;
        }
        else
        {
            MoveToTarget(_startPosition);

            if (transform.position.x == _startPosition.x && _isBusy)
            {
                _isBusy = false;
                _base.MakeBotNull();
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
        }
    }

    public void Busy()
    {
        _isBusy = true;
    }

    public void TakeResource()
    {
        _isTake = true;
    }
}
