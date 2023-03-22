using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Variables
    //Instance
    [HideInInspector] public static ObjectManager instance;

    //Prefabs
    public GameObject bulletPrefab;
    public GameObject asteroidPrefab;

    //Asteroid Variables
    private Dictionary<int, Asteroid> asteroids = new Dictionary<int, Asteroid>();
    private int nextAsteroidID = 0;
    #endregion

    #region Unity Methods
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    #endregion

    #region Custom Methods
    public int addAsteroid(Asteroid asteroid)
    {
        asteroids.Add(nextAsteroidID, asteroid);
        nextAsteroidID++;
        return nextAsteroidID - 1;
    }

    public void removeAsteroid(int index)
    {
        asteroids.Remove(index);

        if(asteroids.Count <= 0) //If no more asteroids are left in the level
        {
            UIManager.instance.showNextLevelButton();
        }
    }
    #endregion
}
