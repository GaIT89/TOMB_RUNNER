using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offSet;
    private Vector3 cameraVector3;

    void LateUpdate()
    {
        cameraVector3 = playerTransform.position + offSet;
        cameraVector3.x = 0f;
        transform.position = cameraVector3;
    }
}
