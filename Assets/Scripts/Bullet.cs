using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    public float life = 5f; //How long the bullet lasts in seconds before being destroyed
    public float speed = 50f; //How quickly the bullet moves
    #endregion

    #region Unity Methods
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        if (life > 0)
        {
            life -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) //Upon colliding with a collider
    {
        if(collision.gameObject.GetComponent<Asteroid>()) //If the collider is an asteroid
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            asteroid.removeHealth(transform.up);
        }

        Destroy(gameObject);
    }
    #endregion
}
