using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    [System.Serializable]
    public struct KeySetup
    {
        public string keyName;
        public string defaultKey;
        public string tempKey;
    }


    public KeySetup[] defaultSetup;

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        //DialogScript.isDialogOpen = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MenuLayout()
    {
    #if UNITY_EDITOR
        MainMenu.screen.x = Screen.width / 16;
        MainMenu.screen.y = Screen.height / 9;
    #endif
        if (GUI.Button(new Rect(MainMenu.screen.x * 6, MainMenu.screen.y * 4, MainMenu.screen.x * 3, MainMenu.screen.y * 1), "Return"))
        {
            Unpause();
        }
        //play 

        if (GUI.Button(new Rect(MainMenu.screen.x * 6, MainMenu.screen.y * 6, MainMenu.screen.x * 3, MainMenu.screen.y * 1),"Main Menu"))
        {
            isPaused = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }


        if (GUI.Button(new Rect(MainMenu.screen.x * 6, MainMenu.screen.y * 8, MainMenu.screen.x * 3, MainMenu.screen.y * 1), "Exit")) //exit
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }

        GUI.Box(new Rect(MainMenu.screen.x * 4, MainMenu.screen.y * 0, MainMenu.screen.x * 7, MainMenu.screen.y * 3), ""); //title
    }

    private void OnGUI()
    {
        if (isPaused)
        {
            MenuLayout();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Unpause();
#if UNITY_EDITOR
        if (!MainMenu.keys.ContainsKey("Up")) // run if dict doesn't have a key
        {
            for (int i = 0; i < defaultSetup.Length; i++)
            {
                MainMenu.keys.Add(defaultSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(defaultSetup[i].keyName, defaultSetup[i].defaultKey)));
                print(defaultSetup[i].keyName + ": " + defaultSetup[i].defaultKey);
            }
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(MainMenu.keys["Escape"]))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }
}
