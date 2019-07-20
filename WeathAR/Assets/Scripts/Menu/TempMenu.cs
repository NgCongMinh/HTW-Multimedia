using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	/**
     * Handles logic for the temperature unit settings component.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     *
     */
	public class TempMenu : MonoBehaviour
	{
		/**
		 * Opens the menu scene.
		 */
		public void OpenMenu(){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
		}
	}
}
