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
    private int id = 0;
    private Vector2 direction = new Vector2(0, 0); //Direction that the asteroid is moving in
    private float speed = 5f;
    private int health = 5; //If this reaches 0, the asteroid either splits or gets destroyed.
    private int[] scales = new int[] {12, 10, 8, 6, 4};
    [SerializeField] private int scaleIndex = 0;
    #endregion

    #region Unity Methods
    void Start()
    {
        id = ObjectManager.instance.addAsteroid(this); //Add the asteroid to the Object Manager and get the ID

        body = GetComponent<Rigidbody>();

        //Ensure the scale of the GameObject is consistent with the scale stored here
        if(transform.localScale.x != scales[scaleIndex]) transform.localScale = new Vector3(scales[scaleIndex], scales[scaleIndex], scales[scaleIndex]);

        //Set the direction and speed to be random
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

    #region Custom Methods
    public void removeHealth(Vector3 bulletDirection, int damage = 1)
    {
        health -= damage;

        if(health <= 0 && scaleIndex < scales.Length - 1) //If the asteroid has no health left and it can still go down in size
        {
            health = 5;
            scaleIndex++;
            setScaleAndDirection(scaleIndex, new Vector2(-bulletDirection.z, bulletDirection.x));
            Asteroid asteroid = Instantiate(ObjectManager.instance.asteroidPrefab, transform.position, Quaternion.identity).GetComponent<Asteroid>();
            asteroid.setScaleAndDirection(scaleIndex, new Vector2(bulletDirection.z, -bulletDirection.x));
        } else if(health <= 0) //If the asteroid has no health left and it has reached its smallest size
        {
            ObjectManager.instance.removeAsteroid(id); //Remove the asteroid from the Object Manager
            Destroy(gameObject);
        }
    }

    public void setScaleAndDirection(int newScaleIndex, Vector2 newDir)
    {
        scaleIndex = newScaleIndex;
        transform.localScale = new Vector3(scales[newScaleIndex], scales[newScaleIndex], scales[newScaleIndex]);
        direction = newDir;
    }
    #endregion
}
