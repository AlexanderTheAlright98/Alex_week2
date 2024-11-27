using UnityEngine;
using Cinemachine;

public class CineCamerasPlayer1 : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    public bool isTopDown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isTopDown = !isTopDown;

            if (isTopDown)
            {
                vcam.m_Priority -= 3;
            }

            else
            {
                vcam.m_Priority += 3;
            }
        }
    }
}
