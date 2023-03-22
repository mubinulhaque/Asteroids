using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Variables
    //Instance
    public static UIManager instance;

    //Private Variables
    [SerializeField] private GameObject restartButton;
    #endregion

    #region Unity Methods
    void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    #endregion

    #region Custom Methods
    public void showRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
