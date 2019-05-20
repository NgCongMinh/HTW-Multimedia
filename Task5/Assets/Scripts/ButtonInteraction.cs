using UnityEngine;
using Vuforia;

public class ButtonInteraction : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject target;

    private bool rotateStatus;

    private Vector3 rotationVector;

    private bool moveStatus;

    private Vector3 moveVector;

    void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log(vb.VirtualButtonName);

        switch (vb.VirtualButtonName)
        {
            case "Button4":
                moveVector = Vector3.right;
                moveStatus = true;
                break;
            case "Button3":
                moveVector = Vector3.left;
                moveStatus = true;
                break;
            case "Button1":
                rotationVector = Vector3.down;
                rotateStatus = true;
                break;
            case "Button2":
                rotationVector = Vector3.down;
                rotateStatus = true;
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        moveStatus = false;
        rotateStatus = false;
    }

    public void Update()
    {
        
        if (rotateStatus)
        {
            Debug.Log("ROTATE");
            Rotate(rotationVector);
        }

        if (moveStatus)
        {
            Debug.Log("MOVE");
            Move(moveVector);
        }
    }

    private void Move(Vector3 movement)
    {
        target.transform.position += movement * 0.1f * Time.deltaTime;
    }

    private void Rotate(Vector3 rotation)
    {
        target.transform.Rotate(rotation, 10.0f * Time.deltaTime);
    }
}