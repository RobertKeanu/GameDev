using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField] private Transform _firepoint;
    [SerializeField] private GameObject _bullet;
    private float _timebetween;
    [SerializeField] private float _starttime;
    void Update()
    {
        if (_timebetween <= 0)
        {
            Instantiate(_bullet, _firepoint.position, _firepoint.rotation);
            _timebetween = _starttime;
        }
        else
        {
            _timebetween -= Time.deltaTime;
        }
    }
}
