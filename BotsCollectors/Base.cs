using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private BotMover[] _bots;
    [SerializeField] private DetectedResource _detectedResource;

    private BotMover[] _currentBots;
    private bool _detected = false;
    private int _resourceIndex = 0;
    private int _botIndex = 0;
    public bool Detected => _detected;

    void Start()
    {
        _currentBots = new BotMover[_bots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentBots[_botIndex] == null)
        {
            FindTargetForBot();
        }
    }

    private void FindTargetForBot()
    {
        if (_detectedResource.Targets.Length > 0)
        {
            _currentBots[_botIndex] = _bots[_botIndex];

            if (_resourceIndex < _detectedResource.Targets.Length)
            {
                if (_currentBots[_botIndex] != null && !_currentBots[_botIndex].IsBusy)
                {
                    if (_botIndex > 0 && _resourceIndex++ < _detectedResource.Targets.Length)
                    {
                        _resourceIndex++;
                    }
                }
            }
            else
            {
                _resourceIndex = 0;
            }

            _detected = true;
        }
    }

    public void BotMoveToResource()
    {
        if (_detectedResource.GetResource(_resourceIndex) != null)
        {
            if (_currentBots[_botIndex].transform.position.x != _detectedResource.GetResource(_resourceIndex).transform.position.x)
            {
                _currentBots[_botIndex].MoveToTarget(_detectedResource.GetResource(_resourceIndex).transform.position);
            }
            else
            {
                _botIndex++;

                if (_botIndex >= _bots.Length)
                {
                    _botIndex = 0;
                }
            }
        }
    }

    public void ChangeDetectedFalse()
    {
        _detected = false;
    }

    public void MakeBotNull()
    {
        _currentBots[_botIndex] = null;
    }
}
