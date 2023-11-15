using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private int _resourceUnit = 1;

    public int ResourceUnit => _resourceUnit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BotMover>(out BotMover botMover))
        {
            Destroy(gameObject);
        }
    }
}
