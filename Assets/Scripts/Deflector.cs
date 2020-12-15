using UnityEngine;

public class Deflector : MonoBehaviour
{

	private Rigidbody2D rb;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Asteroid") {
			rb = col.GetComponent<Rigidbody2D>();
			rb.velocity = -rb.velocity;
		}

		else
			return;
	}

}
