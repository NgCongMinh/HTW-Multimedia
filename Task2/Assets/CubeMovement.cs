using System.Collections;
using System.Collections.Generic;
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
        registerKeyListener();
    }

    private void registerKeyListener()
    {
        var move = new Vector3(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical"), 
            0
            );
        transform.position += move * speed * Time.deltaTime;
    }

}
