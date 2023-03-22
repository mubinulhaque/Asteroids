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
    [SerializeField] private GameObject nextLevelButton;
    #endregion

    #region Unity Methods
    void Awake()
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

    public void showNextLevelButton()
    {
        nextLevelButton.SetActive(true);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
