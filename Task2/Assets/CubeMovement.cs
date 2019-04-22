using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RegisterKeyListener();
    }

    private void RegisterKeyListener()
    {
        var moveDirection = transform.TransformDirection(new Vector3(
            0,
            0,
            Input.GetAxis("Vertical")));
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}