using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Transform planeTarget;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - planeTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = planeTarget.position + offset;
    }
}
