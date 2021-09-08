using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class WaterFloater : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight = 0f;

    Rigidbody _rigidbody;

    bool _underWater;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if(difference < 0)
        {
            _rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);

            if (!_underWater)
            {
                _underWater = true;
                SwitchUnderWaterState(true);
            }
        }
        else if (_underWater)
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
