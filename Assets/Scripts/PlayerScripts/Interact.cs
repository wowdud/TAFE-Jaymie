using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("3D Game/ Player Scripts/ Interact")]

public class Interact : MonoBehaviour
{
    #region Update
    void Update()
    {
        // if interact key is pressed, cast a ray forward from the camera
        if (Input.GetKeyDown(MainMenu.keys["Interact"]))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //Assigning ray origin.
            RaycastHit hitInfo;
            // do something if there's an object 10(?) units in front. Can be adjustable.
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag interact
                if (hitInfo.collider.tag == "NPC")
                {
                    print("That's an NPC");
                    if (hitInfo.collider.gameObject.GetComponent<DialogScript>())
                    {
                        if (!PauseMenu.isPaused)
                        {
                            hitInfo.collider.gameObject.GetComponent<DialogScript>().isDialogOpen = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        }
                    }
                }
                #endregion
                #region Item interact
                if (hitInfo.collider.CompareTag("Item"))
                {
                    print("That's an item");
                }
                #endregion
            }
        }

        #endregion
    }


    void Start()
    {
        
    }

}
