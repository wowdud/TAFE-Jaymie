using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    [System.Serializable]
    public struct KeySetupUI
    {
        public string keyName;
        public Text keyDisplayText;
        public string defaultKey;
    }
    public KeySetupUI[] keySetup;
    public GameObject currentKey;
    public Color32 changedKey = new Color32(60, 171, 249, 255);
    public Color32 selectedKey = new Color32(239, 116, 36, 255);

    private void Start()
    {
        for (int i = 0; i < keySetup.Length; i++)
        {
            keys.Add(keySetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keySetup[i].keyName, keySetup[i].defaultKey)));
            keySetup[i].keyDisplayText.text = keys[keySetup[i].keyName].ToString();
        }
    }
    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
    public void ChangeKey(GameObject clickedKey)
    {
        currentKey = clickedKey;
        if (clickedKey != null)
        {
            currentKey.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI()
    {
        string newKey = "";
        Event bind = Event.current;
        if (currentKey != null)
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
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changedKey;

                currentKey.name = null;
            }
            
        }
    }
}


