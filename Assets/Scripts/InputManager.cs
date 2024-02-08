using UnityEngine;


public static class InputManager 
{
    private static float inputX;
    private static float inputZ;
    private static float inputY;

    [Header("Mouse")]
    private static float mousePosX;

    private static float mousePosY;
    
    public static Vector3 GetInput3D()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        inputY = Input.GetAxis("Jump");
        return new Vector3(inputX, inputY,  inputZ);
    }

    public static Vector3 GetRawInput3D()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        inputY = Input.GetAxis("Jump");
        return new Vector3(inputX, inputY, inputZ);
    }

    public static Vector2 GetMouseDragInput()
    {
        mousePosX = Input.GetAxis("Mouse X");
        mousePosY = Input.GetAxis("Mouse Y");
        return new Vector2(mousePosX, mousePosY);
    }
}
