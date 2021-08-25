using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public static Vector2 screen;

    public Vector2 scrollPosition;

    public Resolution[] resolutions;
    public string[] resolutionName;
    public int resolutionIndex;
    public bool showResOptions;

    public bool areOptionsOpen;
    public string[] idList;
    public int selectedOption;
    public AudioMixer audioMixer;
    public float masterVolumeFloat = 0.0f;
    float dbMasterVolume;
    public float sfxVolumeFloat = 0.0f;
    float dbSFXVolume;
    public float musicVolumeFloat = 0.0f;
    float dbMusicVolume;
    bool muteAll;
    string buttonName = "Mute";
    string testString;

    #region Unused keycodes
    /*
    public string upKey = "W";
    public KeyCode upKeyCode;

    public static string downKey = "S";
    public static KeyCode downKeyCode;

    public static string leftKey = "A";
    public static KeyCode leftKeyCode;

    public static string rightKey = "D";
    public static KeyCode rightKeyCode;
    */
    #endregion

    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    [System.Serializable]
    public struct KeySetup
    {
        public string keyName;
        public string defaultKey;
        public string tempKey;
    }


    public KeySetup[] defaultSetup;

    public KeySetup currentKey;


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        #region Resolution
        resolutions = Screen.resolutions;
        resolutionName = new string[resolutions.Length];
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionName[i] = resolutions[i].width + " x " + resolutions[i].height;
        }
        #endregion

        #region Keybinds
        for (int i = 0; i < defaultSetup.Length; i++)
        {
            keys.Add(defaultSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(defaultSetup[i].keyName, defaultSetup[i].defaultKey)));
            print(defaultSetup[i].keyName + ": " + defaultSetup[i].defaultKey);
        }
        #endregion

    }

    void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

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
            SceneManager.LoadScene(2);
        }
        if (GUI.Button(new Rect(screen.x * 10, screen.y * 4, screen.x * 1, screen.y * 1), "3D"))
        {
            SceneManager.LoadScene(4);
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

    public void Keybinds()
    {
        string newKey = "";
        Event bind = Event.current;
        if (currentKey.keyName != null)
        {
            if (bind.isKey)
            {
                newKey = bind.keyCode.ToString();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            if (newKey != "")
            {
                testString = newKey;
                keys[currentKey.keyName] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                Debug.Log(currentKey.keyName + ": " + newKey);
                currentKey.keyName = null;
            }
        }
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
            SaveKeys();
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
                masterVolumeFloat = GUI.HorizontalSlider(new Rect(screen.x * 2, screen.y * 3.25f, screen.x * 5, screen.y * 2), masterVolumeFloat, 0.0f, 1.0f);
                if (masterVolumeFloat != 0)
                   {
                    dbMasterVolume = Mathf.Log10(masterVolumeFloat) * 20f;
                   }
                else
                   {
                    dbMasterVolume = -144.0f;
                   }
                audioMixer.SetFloat("masterVolume", dbMasterVolume);

                if (GUI.Button(new Rect(screen.x * 7, screen.y * 2, screen.x * 1.25f, screen.y * 1), buttonName))
                {
                   muteAll = !muteAll;
                    if (muteAll)
                    {
                        buttonName = "Unmute";
                        masterVolumeFloat = 0.0f;
                    }
                    else
                    {
                        buttonName = "Mute";
                        masterVolumeFloat = 1.0f;
                    }
                }

                //SFX
                GUI.Box(new Rect(screen.x * 9, screen.y * 2, screen.x * 5, screen.y * 2), "SFX");
                sfxVolumeFloat = GUI.HorizontalSlider(new Rect(screen.x * 9, screen.y * 3.25f, screen.x * 5, screen.y * 2), sfxVolumeFloat, 0.0f, 1.0f);
                if (sfxVolumeFloat != 0)
                {
                    dbSFXVolume = Mathf.Log10(sfxVolumeFloat) * 20f;
                }
                else
                {
                    dbSFXVolume = -144.0f;
                }
                audioMixer.SetFloat("sfxVolume", dbSFXVolume);

                //Music
                GUI.Box(new Rect(screen.x * 5.5f, screen.y * 5, screen.x * 5, screen.y * 2), "Music");
                musicVolumeFloat = GUI.HorizontalSlider(new Rect(screen.x * 5.5f, screen.y * 6.25f, screen.x * 5, screen.y * 2), musicVolumeFloat, 0.0f, 1.0f);
                if (musicVolumeFloat != 0)
                {
                    dbMusicVolume = Mathf.Log10(musicVolumeFloat) * 20f;
                }
                else
                {
                    dbMusicVolume = -144.0f;
                }
                audioMixer.SetFloat("musicVolume", dbMusicVolume);
                break;
            case 1:
                //Graphics

                //Resolution
                if ((GUI.Button(new Rect(screen.x * 7, screen.y * 2, screen.x * 4f, screen.y * 1f), "Resolutions")))
                {
                    showResOptions = !showResOptions;
                }
                if (showResOptions)
                {
                    GUI.Box(new Rect(screen.x * 7, screen.y * 3, screen.x * 4, screen.y * 4), "");
                    scrollPosition = GUI.BeginScrollView(new Rect(screen.x * 7, screen.y * 3, screen.x * 4, screen.y * 4), scrollPosition, new Rect(0,0,2.75f*screen.x,0.5f*screen.y*resolutions.Length));
                    for (int i = 0; i < resolutions.Length; i++)
                    {
                        if (GUI.Button(new Rect(0, i*0.5f*screen.y, 3.75f * screen.x, 0.5f * screen.y), resolutionName[i]))
                        {
                            Screen.SetResolution(resolutions[i].width, resolutions[i].height, Screen.fullScreen);
                            showResOptions = false;
                        }
                    }

                    GUI.EndScrollView();
                }


                //Quality

                //Fullscreen

                bool fullscreenToggle = false;
                if (GUI.Button(new Rect(screen.x * 2, screen.y * 3, screen.x * 3, screen.y * 1), "Toggle Fullscreen"))
                {
                    fullscreenToggle = !fullscreenToggle;
                    if (fullscreenToggle)
                    {
                        Screen.fullScreen = !Screen.fullScreen;
                    }
                    else
                    {
                        Screen.fullScreen = !Screen.fullScreen;
                    }

                }


                break;
            case 2:
                //Keybindings
                for (int i = 0; i < defaultSetup.Length; i++)
                {
                    if (GUI.Button(new Rect(screen.x * 6, (i * screen.y * 0.75f) + (2*screen.y), screen.x * 4f, screen.y * 0.5f), defaultSetup[i].keyName + ": " + testString))
                    {
                        currentKey.keyName = defaultSetup[i].keyName;
                        testString = "Press a key";
                    }
                }
                if (currentKey.keyName != null)
                {
                    Keybinds();
                }
                #region Deprecated button code
                /*
                if (GUI.Button(new Rect(screen.x * 3, screen.y * 4, screen.x * 3, screen.y * 1), "Down: " + downKey))
                {
                    if (bind.isKey)
                    {
                        downKeyCode = bind.keyCode;
                        downKey = downKeyCode.ToString();
                    }
                }
                if (GUI.Button(new Rect(screen.x * 10, screen.y * 2, screen.x * 3, screen.y * 1), "Left: " + leftKey))
                {
                    if (bind.isKey)
                    {
                        leftKeyCode = bind.keyCode;
                        leftKey = leftKeyCode.ToString();
                    }
                }
                if (GUI.Button(new Rect(screen.x * 10, screen.y * 4, screen.x * 3, screen.y * 1), "Right: " + rightKey))
                {
                    if (bind.isKey)
                    {
                        rightKeyCode = bind.keyCode;
                        rightKey = rightKeyCode.ToString();
                    }
                }
                */
                #endregion

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
