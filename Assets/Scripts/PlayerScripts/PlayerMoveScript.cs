using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dx = 0;
        float dy = 0;

        if (Input.GetKey(MainMenu.keys["Up"]))
        {
            dy += 1;
        }
        if (Input.GetKey(MainMenu.keys["Down"]))
        {
            dy += -1; 
        }
        if (Input.GetKey(MainMenu.keys["Left"]))
        {
            dx += -1;  
        }
        if (Input.GetKey(MainMenu.keys["Right"]))
        {
            dx += 1; 
        }
        Vector3 movement = new Vector3(dx, dy, 0f).normalized * Time.deltaTime * speed;
        Vector3 newPosition = new Vector3((Mathf.Clamp(transform.position.x + movement.x, -24.0f, 24.0f)), Mathf.Clamp(transform.position.y + movement.y, -13.25f, 13.25f), 0f);
        transform.position = newPosition;
    }
}
