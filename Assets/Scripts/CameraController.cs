using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;

    private void Start()
    {
        Transform player;

        cv = GetComponent<CinemachineVirtualCamera>();
        player = GameManager.Instance.Player.transform;

        if(cv != null)
        {
            if(player != null)
            {
                cv.Follow = player;
                Debug.Log("Todo OK");
            }
            else
            {
                Debug.Log("player not found");
            }
        }
        else
        {
            Debug.Log("CinemachineVirtualCamera not found");
        }
    }
}
