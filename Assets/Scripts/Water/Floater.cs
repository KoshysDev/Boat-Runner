using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody boatRigidbody;

    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float waterDrag = 0.9f;
    public float waterAngularDrag = 0.5f;
    public int floaterNummer = 1;

    private float _waveHeight;

    private void Update()
    {
        _waveHeight = WavePhysic.wavePhysic.GetWaveHeight(transform.position.x);
    }

    private void FixedUpdate()
    {
        boatRigidbody.AddForceAtPosition(Physics.gravity / floaterNummer, transform.position,
            ForceMode.Acceleration);

        if (transform.position.y < _waveHeight)
        {
            float dissplacementMultiplier = Mathf.Clamp01((_waveHeight - transform.position.y) / 
                depthBeforeSubmerged) * displacementAmount;

            boatRigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * 
                dissplacementMultiplier, 0f), transform.position, ForceMode.Acceleration);

            boatRigidbody.AddForce(dissplacementMultiplier * -boatRigidbody.velocity * 
                waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

            boatRigidbody.AddTorque(dissplacementMultiplier * -boatRigidbody.angularVelocity *
                waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
    }
}
