using UnityEngine;

public class CubeRotateMovement : MonoBehaviour
{
    public float rotationSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            0,
            Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime,
            0
        );
    }
}