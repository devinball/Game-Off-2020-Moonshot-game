using UnityEngine;

public class EndTrigger : MonoBehaviour
{

	public GameObject WinningText;

	void Awake() {
		WinningText.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player")
			PlayerWins();
	}

	void PlayerWins() {
		Debug.Log("win");
		Time.timeScale = 0f;
		WinningText.SetActive(true);
	}

}
