using UnityEngine;

namespace Controller
{
    public class QRTargetController : MonoBehaviour
    {
        private TargetController controller;

        public void Start()
        {
            controller = GameObject.Find("SceneController").GetComponent<TargetController>();
        }

        public void Register()
        {
            controller.Register(transform.gameObject);
        }
    }
}