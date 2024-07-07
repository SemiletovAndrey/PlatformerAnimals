using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject menuWindow;

    [SerializeField] private MonoBehaviour[] componentsToDisable;
    public void OpenMenuWindow()
    {
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
        foreach (var component in componentsToDisable)
        {
            component.enabled = false;
        }
        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        menuButton.SetActive(true);
        menuWindow.SetActive(false);
        foreach (var component in componentsToDisable)
        {
            component.enabled = true;
        }
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
