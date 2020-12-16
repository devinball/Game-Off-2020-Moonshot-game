using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	private Rigidbody2D rb;
	private Vector3 AsteroidScale = Vector3.zero;

	void OnEnable() {
		rb = GetComponent<Rigidbody2D>();
		transform.localScale = RandomScale(AsteroidScale);
		StartCoroutine(LateCall());
	}

	void FixedUpdate() {
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 20);
	}

	//if object hits something return it to object pool
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag != "Asteroid") {
			transform.localScale = RandomScale(AsteroidScale);
			rb.velocity = Vector2.zero;
			gameObject.SetActive(false);
		}
	}

	//randomize the scale of the object
	Vector3 RandomScale(Vector3 Scale) {
		Scale.x = Random.Range(5, 10);
		Scale.y = Random.Range(5, 10);
		Scale.z = 0.0001f;
		return Scale;
	}

	//if object exists for too long return it to object pool
	private IEnumerator LateCall() {
    	yield return new WaitForSeconds(10);
    	rb.velocity = Vector2.zero;
      gameObject.SetActive(false);
   }

}