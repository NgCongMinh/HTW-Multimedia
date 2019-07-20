using UnityEngine;

namespace Controller
{
    /**
     * Handles logic for the qr target component.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    public class QrTargetController : MonoBehaviour
    {
        private TargetController controller;

        public void Start()
        {
            controller = GameObject.Find("SceneController").GetComponent<TargetController>();
        }

        /**
         * Registers the attached object to the TargetController.
         */
        public void Register()
        {
            controller.Register(transform.gameObject);
        }
    }
}