using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMananger : MonoBehaviour
{

	public string Scene;

	//load scene
	public void LoadNextScene() {
		SceneManager.LoadScene(Scene);
		Time.timeScale = 1f;
	}

}
