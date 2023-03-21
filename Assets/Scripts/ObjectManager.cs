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
    #endregion

    #region Unity Methods
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    #endregion
}
