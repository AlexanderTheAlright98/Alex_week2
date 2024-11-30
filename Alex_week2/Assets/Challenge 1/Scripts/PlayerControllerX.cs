using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
//Commented this bit out because it won't let me build my game. No idea why
//Also deleted the video that comes with this, because it throws a warning when I switch to WebGL for building the project

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Tilt the plane up/down based on up/down arrow keys
        // I've used -verticalInput here, so the up/down controls are reversed. Pressing up to fly up feels more intuitive to me
        transform.Rotate(rotationSpeed * -verticalInput * Time.deltaTime, 0, 0);
    }
}
