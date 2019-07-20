using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
	
	public void OpenFAQ(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OpenTemp(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void OpenMain(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
