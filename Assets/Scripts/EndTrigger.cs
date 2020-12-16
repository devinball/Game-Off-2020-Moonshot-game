using UnityEngine;

public class EndTrigger : MonoBehaviour
{

	public GameObject WinningText;

	//at begining of game disable winning text
	void Awake() {
		WinningText.SetActive(false);
	}

	//detect if player landed on pad
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player")
			PlayerWins();
	}

	//player win
	void PlayerWins() {
		Debug.Log("win");
		Time.timeScale = 0f;
		WinningText.SetActive(true);
	}

}
