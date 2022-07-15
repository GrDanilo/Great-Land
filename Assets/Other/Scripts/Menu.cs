using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float Coins;

    private void FixedUpdate() 
    {
        if (Application.platform == RuntimePlatform.Android) 
        { 
            if (Input.GetKeyDown(KeyCode.Escape)) 
            { 
                Application.Quit(); 
            } 
        } 
    }

    public void LoadLocalGame()
    {
        SceneManager.LoadScene("Local game");
    }
}
