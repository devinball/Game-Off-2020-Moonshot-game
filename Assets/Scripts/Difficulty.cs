using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

	//sets difficulty which controls enemy cooldown.
	public static float CoolDown;

	public void Easy() {
		CoolDown = 2f;
	}

	public void Normal() {
		CoolDown = 1f;
	}

	public void Hard() {
		CoolDown = 0.5f;
	}

	public void Imposible() {
		CoolDown = 0.05f;
	}

}
