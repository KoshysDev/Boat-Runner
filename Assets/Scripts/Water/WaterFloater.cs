using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class WaterFloater : MonoBehaviour
{
    public Transform[] floaterPoints;

    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody _rigidbody;

    bool _underWater;

    int _floatersUnderwater;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _floatersUnderwater = 0;

        for (int i = 0; i < floaterPoints.Length; i++)
        {
            float difference = floaterPoints[i].position.y - waterHeight;

            if (difference < 0)
            {
                _rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaterPoints[i].position, ForceMode.Force);
                _floatersUnderwater += 1;

                if (!_underWater)
                {
                    _underWater = true;
                    SwitchUnderWaterState(true);
                }
            }
        }
        
        if (_underWater && _floatersUnderwater == 0)
        {
            _underWater = false;
            SwitchUnderWaterState(false);
        }
    }

    private void SwitchUnderWaterState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            _rigidbody.drag = underWaterDrag;
            _rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            _rigidbody.drag = airDrag;
            _rigidbody.angularDrag = airAngularDrag;
        }
    }
}
