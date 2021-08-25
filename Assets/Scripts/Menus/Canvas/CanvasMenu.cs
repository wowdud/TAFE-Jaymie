using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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
    }
}
