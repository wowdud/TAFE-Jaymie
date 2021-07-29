using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Vector2 screen;
    public bool isOptionOpen;

    void OnGUI()
    {
        //16:9 Aspect Ratio
        screen.x = Screen.width/16;
        screen.y = Screen.height/9;
        Grid();
        if (!isOptionOpen)
        {
            MenuLayout();
        }
        
    }

    void Grid()
    {
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(x*screen.x, y*screen.y, screen.x, screen.y), "");
            }
        }
    }
    void MenuLayout()
    {
        if (GUI.Button(new Rect(screen.x * 6, screen.y * 4, screen.x * 3, screen.y * 1), "Play"))
        {
            SceneManager.LoadScene(1);
        }
        //play 

        GUI.Box(new Rect(screen.x * 0, screen.y * 0, screen.x * Screen.width, screen.y *Screen.height), ""); //background

        if (GUI.Button(new Rect(screen.x * 6, screen.y * 6, screen.x * 3, screen.y * 1), "Options"))
        {
            isOptionOpen = true;
        }
        //options

        if(GUI.Button(new Rect(screen.x * 6, screen.y * 8, screen.x * 3, screen.y * 1), "Exit")) //exit
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; 
            #endif
            Application.Quit();
        }

        GUI.Box(new Rect(screen.x * 4, screen.y * 0, screen.x * 7, screen.y * 3), ""); //title

        


        //needs Background, title, play, options, exit
    }
}
