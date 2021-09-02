using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("3D Game/ NPC Scripts/ Dialogue")]

public class DialogScript : MonoBehaviour
{
    [Header("References")]
    public bool isDialogOpen = false;
    public string[] dialogText;
    public int dialogIndex; // index of current line of dialogue
    public string npcName;

    private void OnGUI()
    {
        //if dialogue can be seen on screen
        if (isDialogOpen)
        {
            GUI.Box(new Rect(0, MainMenu.screen.y * 6 ,Screen.width ,MainMenu.screen.y * 3), npcName+ ": " + dialogText[dialogIndex]);
            //dialogue box should take up bottom 3rd of the screen
            //if not at the end of the dialogue
            if (dialogIndex < dialogText.Length - 1)
            {
                if (GUI.Button(new Rect(MainMenu.screen.x * 15, MainMenu.screen.y * 8.5f, MainMenu.screen.x, MainMenu.screen.y * 0.5f), "Next"))
                {
                    dialogIndex++;
                }
            }
            //else we are at the end
            else
            {
                if (GUI.Button(new Rect(MainMenu.screen.x * 15, MainMenu.screen.y * 8.5f, MainMenu.screen.x, MainMenu.screen.y * 0.5f), "Bye"))
                {
                    //close dialogue box
                    isDialogOpen = false;
                    //index to 0
                    dialogIndex = 0;
                    //free cursor
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    //let the character move
                }
            }
        }
    }


    void Start()
    {
#if UNITY_EDITOR
        MainMenu.screen.x = Screen.width / 16;
        MainMenu.screen.y = Screen.height / 9;
#endif
    }


    void Update()
    {
        
    }
}
