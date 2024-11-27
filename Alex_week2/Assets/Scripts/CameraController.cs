using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTarget;
    public Vector3 offset;
    public Vector3 offsetFPS;
    public bool isFPS = false;

    // Borrowed most of this code from the taster session Roll a Ball game, to make the camera follow the player. I know I can move the camera by using Input.GetKeyDown, but this seems more elegant.    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTarget.position;
    }

    // This is called one frame after Update
    //void LateUpdate()
    //{
    //    if (!isFPS)
    //    {
    //        transform.position = playerTarget.position + offset;
    //    }
    //    else
    //    {
    //        transform.position = playerTarget.position + offsetFPS;
    //    }

    //    if (Input.GetKeyDown(KeyCode.C)) isFPS = !isFPS;

        //transform.position = playerTarget.position + new Vector3(0, 7, -10) This also works, but the values are hardcoded as opposed to the method above.
        //transform.position = playerTarget.position + (playerTarget.forward * offset.z) + new Vector3(0, offset.y, 0);
        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x, playerTarget.eulerAngles.y, transform.eulerAngles.z);
}
