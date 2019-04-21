using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 1;

    public Vector3 moveVector = Vector3.zero;

    public GameObject myFollowerObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myFollowerObject.transform.position = transform.position + new Vector3(0, 0, 0.5f);

        if (transform.position.z >= 10)
        {
            moveVector = new Vector3(0, 0, -1);
        }
        else if (transform.position.z <= 0)
        {
            moveVector = new Vector3(0, 0, 1);
        }

        transform.position += (moveVector * speed * Time.deltaTime);

        // rotate in random directions
        transform.rotation *= Quaternion.Euler(
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f));
    }

    private void OnTriggerEnter(Collider other)
    {     
        // change direction when collidate           
        moveVector *= -1;
    }
}