using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    /**
     * Handles logic for the menu component.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     *
     */
    public class Menu : MonoBehaviour
    {
        /**
         * Opens the FAQ scene.
         */
        public void OpenFAQ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /**
         * Opens the temperature unit setting scene.
         */
        public void OpenTemp()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        /**
         * Opens the main scene.
         */
        public void OpenMain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}