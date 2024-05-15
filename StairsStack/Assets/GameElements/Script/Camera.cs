using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
   
    public Vector3 offset = new Vector3(-1f, 0.55f, -1.5f); 
    public Vector3 rotation = new Vector3(0f,43f, 0f);
    public float smoothSpeed = 10f;


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*2f * Time.deltaTime);
        transform.position = smoothedPosition;
        Quaternion desiredRotation = Quaternion.Euler(rotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);

    }

}
