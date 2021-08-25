using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("3D Game/ Player Scripts/ Mouse movement")]

public class MouseMove : MonoBehaviour
{
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    [Header("Rotation")]
    public RotationalAxis axis = RotationalAxis.MouseX;

    [Header("Sensitivity")]
    [Range(0, 100)]
    public static float xSens = 5;
    [Range(0, 100)]
    public static float ySens = 5;

    [Header("Y Rotation Clamp")]
    public float Ymax;
    public float Ymin;
    float yRot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (GetComponent<Camera>())
        {
            axis = RotationalAxis.MouseY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            #region MouseX
            if (axis == RotationalAxis.MouseX)
            {
                transform.Rotate(0, Input.GetAxisRaw("Mouse X") * xSens, 0);
            }
            #endregion

            #region MouseY
            else
            {
                yRot += Input.GetAxisRaw("Mouse Y") * ySens;
                yRot = Mathf.Clamp(yRot, Ymin, Ymax);
                transform.localEulerAngles = new Vector3(-yRot, 0, 0);
            }
            #endregion
        }

    }
}
