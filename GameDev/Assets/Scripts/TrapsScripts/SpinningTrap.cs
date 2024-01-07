using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _xAngleSpeed;
    [SerializeField] private float _yAngleSpeed;
    [SerializeField] private float _zAngleSpeed;
    
    void Update()
    {
        transform.Rotate(_xAngleSpeed, _yAngleSpeed, _zAngleSpeed, Space.Self);
    }
}
