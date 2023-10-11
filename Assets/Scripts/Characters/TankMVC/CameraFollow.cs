
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 10, -10); 
    public float smoothSpeed = 0.125f;

    public void SetTarget(Transform Player)
    {
        target = Player;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition =new Vector3( target.position.x + offset.x,offset.y, target.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(45f, 0f, 0f);
    }
}
