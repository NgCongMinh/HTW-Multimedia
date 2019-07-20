using UnityEngine;

namespace Controller
{
    public class PointerController : MonoBehaviour
    {
        private TargetController controller;

        public void Start()
        {
            controller = GameObject.Find("SceneController").GetComponent<TargetController>();
        }

        public void OnTriggerEnter(Collider col)
        {
            if (!col.CompareTag("Marker")) return;

            GameObject target = col.transform.gameObject;
            controller.Register(target);
        }
    }
}