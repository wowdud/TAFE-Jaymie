using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CanvasUI
{
    public class CanvasMenu : MonoBehaviour
    {
        public AudioMixer audioMaster;
        public string mixerName;

        public void CurrentMixer(string name)
        {
            mixerName = name;
        }    
        public void ChangeVolume(float volume)
        {
            audioMaster.SetFloat(mixerName, volume);
        }

        public void ChangeScene(int SceneID)
        {
            SceneManager.LoadScene(SceneID);
        }
        
        public void ExitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }

        public void Quality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        public void SetFullScreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public Resolution[] resolutions;
        public Dropdown resolutionDropdown;

        private void Start()
        {
            if (resolutionDropdown != null)
            {
                resolutions = Screen.resolutions;
                resolutionDropdown.ClearOptions();
                List<string> options = new List<string>();
                int crResIndex = 0;
                for (int i = 0; i < resolutions.Length; i++)
                {
                    string option = resolutions[i].width + " x " + resolutions[i].height;
                    options.Add(option);
                    if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                    {
                        crResIndex = i;
                    }
                }
                resolutionDropdown.AddOptions(options);
                resolutionDropdown.value = (crResIndex);
                resolutionDropdown.RefreshShownValue();
            }
            else
            {
                print("nothing here");
            }
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }    

    }
}
