using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private static bool created = false;
	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			Debug.Log("Awake: " + this.gameObject);
		}
	}

	public void	loadScene(string sceneName)
	{
			// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
			SceneManager.LoadScene(sceneName);
	}
}
