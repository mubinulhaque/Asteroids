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
        Destroy(gameObject);
    }
    #endregion
}
