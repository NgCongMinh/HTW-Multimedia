using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TempMenu : MonoBehaviour
{
	public void OpenMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}
}
