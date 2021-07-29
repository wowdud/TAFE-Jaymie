using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Vector2 screen;
    public bool areOptionsOpen;
    public string[] idList;
    public int selectedOption;
    public AudioMixer audioMixer;

    void OnGUI()
    {
        //16:9 Aspect Ratio
        screen.x = Screen.width/16;
        screen.y = Screen.height/9;
        Grid();
        if (!areOptionsOpen)
        {
            MenuLayout();
        }
        else
        {
            OptionsLayout();
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
            areOptionsOpen = true;
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
    void OptionsLayout()
    {
        //Background
        GUI.Box(new Rect(screen.x * 0, screen.y * 0, screen.x * Screen.width, screen.y * Screen.height), "");

        //Title

        //test button box
        GUI.Box(new Rect(screen.x * 7, screen.y * 0, screen.x * 2, screen.y * 0.6f), idList[selectedOption]);

        //Options background
        GUI.Box(new Rect(screen.x * 1, screen.y * 1, screen.x * 14, screen.y * 7), "");

        //Back button
        if (GUI.Button(new Rect(screen.x * 0, screen.y * 0, screen.x * 1, screen.y * 0.5f), "Back"))
        {
            areOptionsOpen = false;
            selectedOption = 0;
        }

        #region Game Settings
        #region Buttons
            //GUI.Box(new Rect(screen.x * 1, screen.y * 1, screen.x * 4, screen.y * 1), "Sound");
            //GUI.Box(new Rect(screen.x * 7, screen.y * 1.2f, screen.x * 3, screen.y * 0.8f), "SFX");
            //GUI.Box(new Rect(screen.x * 11, screen.y * 1.2f, screen.x * 3, screen.y * 0.8f), "Music");
            //GUI.Box(new Rect(screen.x * 1, screen.y * 3, screen.x * 4, screen.y * 1), "Graphics");
            //GUI.Box(new Rect(screen.x * 7, screen.y * 3.2f, screen.x * 2, screen.y * 0.8f), "Resolution");
            //GUI.Box(new Rect(screen.x * 10, screen.y * 3.2f, screen.x * 2, screen.y * 0.8f), "Quality");
            //GUI.Box(new Rect(screen.x * 13, screen.y * 3.2f, screen.x * 1, screen.y * 0.8f), "Fullscreen");
            //GUI.Box(new Rect(screen.x * 1, screen.y * 5, screen.x * 4, screen.y * 2), "Keybinds");
            //GUI.Box(new Rect(screen.x * 7, screen.y * 5, screen.x * 7, screen.y * 1), "Cursors");
            //GUI.Box(new Rect(screen.x * 7, screen.y * 7, screen.x * 2, screen.y * 0.8f), "Sensitivity");
            //GUI.Box(new Rect(screen.x * 10, screen.y * 7, screen.x * 1, screen.y * 0.8f), "Invert");
            //GUI.Box(new Rect(screen.x * 12, screen.y * 7, screen.x * 2, screen.y * 0.8f), "Icon");
        for (int buttonID = 0; buttonID < idList.Length; buttonID++)
        {
            if (GUI.Button(new Rect(4*(buttonID * screen.x)+ screen.x, 0.75f * screen.y, 2f * screen.x, 0.3f * screen.y), idList[buttonID]))
            {
                selectedOption = buttonID;
            }
        }
        #endregion
        switch (selectedOption)
        {
            case 0:
                //Master
                GUI.Box(new Rect(screen.x * 2, screen.y * 2, screen.x * 5, screen.y * 2), "Master");
                audioMixer.SetFloat("masterVolume",0);

                //SFX
                GUI.Box(new Rect(screen.x * 9, screen.y * 2, screen.x * 5, screen.y * 2), "SFX");

                //Music
                GUI.Box(new Rect(screen.x * 5.5f, screen.y * 5, screen.x * 5, screen.y * 2), "Music");
                break;
            case 1:
                //Graphics

                //Resolution

                //Quality

                //Fullscreen
                break;
            case 2:
                //Keybindings

                break;
            case 3:
                //Cursors

                //Sensitivity

                //Invert

                //Icon
                break;
            default:
                break;
        }
        #endregion
    }
}
