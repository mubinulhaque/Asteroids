using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
public class ShipController : MonoBehaviour
{
    #region Variables
    //Player Components
    private Rigidbody body;

    //Other Private Variables
    private float forwardForce = 0f; //The force currently applied onto the ship to move it forward
    private float turnRate = 0f; //The force currently applied onto the ship to turn it clockwise

    //Prefabs
    public GameObject bulletPrefab;

    //Other Public Variables
    public float movementSpeed = 3000f;
    public float turnSpeed = 1750f;
    #endregion

    #region Unity Methods
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        body.AddTorque(transform.up * turnRate * Time.fixedDeltaTime); //Turn the ship around the ship's y-axis
        body.AddForce(transform.forward * forwardForce * Time.fixedDeltaTime); //Move the ship along the ship's z-axis
    }
    #endregion

    #region Input Methods
    public void setForwardSpeed(InputAction.CallbackContext context)
    {
        forwardForce = context.ReadValue<float>() * movementSpeed;
    }

    public void setTurnRate(InputAction.CallbackContext context)
    {
        turnRate = context.ReadValue<float>() * turnSpeed;
    }
    #endregion
}
