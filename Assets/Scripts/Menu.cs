using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region Custom Methods
    public void switchMenu(GameObject newMenu)
    {
        newMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void switchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    #endregion
}
