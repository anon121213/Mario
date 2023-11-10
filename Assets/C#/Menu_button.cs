using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_button : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
