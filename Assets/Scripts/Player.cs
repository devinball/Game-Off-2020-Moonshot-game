using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

	private bool invulnerable = true;

	public float health = 3;
	public float thrust = 50;

	public GameObject hp3;
	public GameObject hp2;
	public GameObject hp1;
	public GameObject youlost;

	private Rigidbody2D rb;

	private bool up;

	private bool RHeld;
	private bool LHeld;
	private bool DHeld;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		health = 3;
		thrust = 50;
		DefaultAll();
	}

	void Update() {
		if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) || Input.GetKey(KeyCode.Space))
			up = true;
		else
			up	= false;
	}

	void FixedUpdate() {

		if (Input.GetKey(KeyCode.D)) {
			transform.eulerAngles = Vector3.forward * -90;
			RHeld = true;
		}
		else
			RHeld = false;

		if (Input.GetKey(KeyCode.A)) {
			transform.eulerAngles = Vector3.forward * 90;
			LHeld = true;
		}
		else
			LHeld = false;

		if (Input.GetKey(KeyCode.S)) {
			transform.eulerAngles = Vector3.forward * 180;
			DHeld = true;
		}
		else
			DHeld = false;

		if (!RHeld && !LHeld && ! DHeld)
			transform.eulerAngles = Vector3.forward * 0;

		if (up == true)
			rb.AddForce(transform.up * thrust);

		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
		ManageHealth();
	}

	void ManageHealth() {
		if (health == 3)
			return;
		if (health == 2)
			hp3.SetActive(false);
		if (health == 1)
			hp2.SetActive(false);
		if (health == 0)
			PlayerLoose();
	}

	void DefaultAll() {
		hp1.SetActive(true);
		hp2.SetActive(true);
		hp3.SetActive(true);
		youlost.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Asteroid" && health > 0 && !invulnerable)
			health -= 1;
			StartCoroutine(DamageCall());
	}

	//damage cooldown
	 private IEnumerator DamageCall() {
   	yield return new WaitForSeconds(1);
 	  	invulnerable = false;
  }

  void PlayerLoose() {
  	hp1.SetActive(false);
		youlost.SetActive(true);
		Time.timeScale = 0f;
  }

}