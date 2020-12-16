using UnityEngine;

public class Deflector : MonoBehaviour
{

	private Rigidbody2D rb;

	//if asteroid hits trigger sets its velocity to opposite of what it was
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Asteroid") {
			rb = col.GetComponent<Rigidbody2D>();
			rb.velocity = -rb.velocity;
		}

		else
			return;
	}

}
