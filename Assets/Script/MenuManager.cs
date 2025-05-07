using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");  
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credit");
    }

    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("Level");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

   
}
