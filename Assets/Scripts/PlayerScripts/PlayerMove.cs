using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("3D Game/ Player Scripts/ First person movement")]
[RequireComponent(typeof(CharacterController))]

public class PlayerMove : MonoBehaviour
{
    [Header("Character")]
    public Vector3 moveDir;
    private CharacterController _charC;
    [Header("Character Speeds")]
    public float speed;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2.5f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        _charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //MainMenu.keys
        input.y = 0;
        if (Input.GetKey(MainMenu.keys["Up"]))
        {
            input.y = 1;
        }
        if (Input.GetKey(MainMenu.keys["Down"]))
        {
            input.y = -1;
        }

        input.x = 0;
        if (Input.GetKey(MainMenu.keys["Left"]))
        {
            input.x = -1;
        }
        if (Input.GetKey(MainMenu.keys["Right"]))
        {
            input.x = 1;
        }

        if (Input.GetKeyDown(MainMenu.keys["Crouch"]))
        {
            speed = crouchSpeed;
        }
        if (Input.GetKeyUp(MainMenu.keys["Crouch"]))
        {
            speed = walkSpeed;
        }

        if (Input.GetKeyDown(MainMenu.keys["Sprint"]))
        {
            speed = runSpeed;
        }
        if (Input.GetKeyUp(MainMenu.keys["Sprint"]))
        {
            speed = walkSpeed;
        }


        if (_charC.isGrounded)
        {
            moveDir = new Vector3(input.x, 0, input.y);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
            if (Input.GetKey(MainMenu.keys["Jump"]))
            {
               moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        _charC.Move(moveDir * Time.deltaTime);
    }
}
