using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTarget;
    private Vector3 offset;

    // Borrowed most of this code from the taster session Roll a Ball game, to make the camera follow the player. I know I can move the camera by using Input.GetKeyDown, but this seems more elegant.    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerTarget.position;
    }
    private void LateUpdate()
    {
        transform.position = offset + playerTarget.position;
        transform.LookAt(playerTarget.position);

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(0, -0.2f, 0);
        //}

        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(0, 0.2f, 0);
        //}
    }
}
