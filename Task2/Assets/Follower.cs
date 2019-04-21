using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public Transform target;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        transform.LookAt(target);
        transform.position = new Vector3(
            pos.x + offset, 
            pos.y + offset, 
            pos.z + offset
            );
    }
}
