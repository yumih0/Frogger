using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        
    }

public void turnoff()
    {
        Application.Quit();
        Debug.Log("Gra wy³¹czona");
    }
    public void startGry()
    {
        SceneManager.LoadScene("Gra");
    }

    public void tabela()
    {
        SceneManager.LoadScene("Hiscore");
    }
}
