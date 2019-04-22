using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offsetPosition = new Vector3(0, 5, -12);

    [SerializeField] private Space offsetPositionSpace = Space.Self;

    [SerializeField] private bool lookAt = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }
        
        transform.LookAt(target);

        /*
        Vector3 relativePos = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(relativePos);

        
        lookRotation.x = transform.rotation.x;
        lookRotation.z = transform.rotation.z;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed);
        */

        /*
        Vector3 offsetVector = target.transform.position + offset;
        transform.position = offsetVector;
        */
    }
}