using UnityEngine;

namespace Controller
{
    /**
     * Handles logic for the controller component.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     *
     */
    public class PointerController : MonoBehaviour
    {
        private TargetController controller;

        public void Start()
        {
            controller = GameObject.Find("SceneController").GetComponent<TargetController>();
        }

        /**
         * Handles on trigger enter events.
         *
         * @param[in] col collider object
         */
        public void OnTriggerEnter(Collider col)
        {
            if (!col.CompareTag("Marker")) return;

            GameObject target = col.transform.gameObject;
            controller.Register(target);
        }
    }
}