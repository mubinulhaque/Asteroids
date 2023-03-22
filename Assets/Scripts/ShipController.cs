using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
public class ShipController : MonoBehaviour
{
    #region Variables
    //Components
    private Rigidbody body;

    //Other Private Variables
    private float forwardForce = 0f; //The force currently applied onto the ship to move it forward
    private float turnRate = 0f; //The force currently applied onto the ship to turn it clockwise

    //Public Variables
    public Transform muzzle; //Where the bullets are shot from
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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Asteroid>() != null) //If the ship has collided with an asteroid
        {
            UIManager.instance.showRestartButton(); //Show the restart button
            Destroy(gameObject); //Destroy the ship
        }
    }
    #endregion

    #region Input Methods
    public void setForwardSpeed(InputAction.CallbackContext context)
    {
        //context always has a value between -1 and 1, allowing forwardForce to move the ship backwards and forwards
        forwardForce = context.ReadValue<float>() * movementSpeed;
    }

    public void setTurnRate(InputAction.CallbackContext context)
    {
        //context always has a value between -1 and 1, allowing turnRate to turn the ship clockwise or anti-clockwise
        turnRate = context.ReadValue<float>() * turnSpeed;
    }

    public void shoot(InputAction.CallbackContext context)
    {
        if(context.performed) //If the button has been pressed
        {
            //Create a bullet at the muzzle of the ship in the same rotation as the ship
            GameObject bullet = Object.Instantiate(ObjectManager.instance.bulletPrefab, muzzle.position, Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0)) as GameObject;
        }
    }
    #endregion
}
