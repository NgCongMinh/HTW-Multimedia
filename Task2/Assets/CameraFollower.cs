using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offsetPosition = new Vector3(0, 5, -12);

    [SerializeField] private Space offsetPositionSpace = Space.Self;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
            transform.position = target.TransformPoint(offsetPosition);
       

        transform.LookAt(target);
    }
}