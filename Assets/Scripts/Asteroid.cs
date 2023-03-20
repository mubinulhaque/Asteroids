using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
    #region Variables
    //Components
    private Rigidbody body;

    //Other Private Variables
    private Vector2 direction;
    private float speed;
    #endregion

    #region Unity Methods
    void Start()
    {
        body = GetComponent<Rigidbody>();
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        speed = Random.Range(10f, 30f);
    }

    void FixedUpdate()
    {
        //Move the asteroid upwards and sideways linearly
        body.AddForce(direction.x * Time.fixedDeltaTime * speed, 0, direction.y * Time.fixedDeltaTime * speed);
        //Rotate the asteroid in the x direction
        body.AddTorque(0, direction.x, 0);
    }
    #endregion
}
