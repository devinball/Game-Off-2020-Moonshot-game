using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

//	public Transform SpawnPosition;

	private Rigidbody2D rb;

//	private Vector3 Offset = Vector3.zero;
	private Vector3 AsteroidScale = Vector3.zero;

	void OnEnable() {
		rb = GetComponent<Rigidbody2D>();
		transform.localScale = RandomScale(AsteroidScale);
		StartCoroutine(LateCall());
	}

	void FixedUpdate() {
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 20);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag != "Asteroid") {
//			Offset.x = Random.Range(-10, 10);
//			transform.position = SpawnPosition.position + Offset;
			transform.localScale = RandomScale(AsteroidScale);
			rb.velocity = Vector2.zero;
			gameObject.SetActive(false);
		}
	}

	Vector3 RandomScale(Vector3 Scale) {
		Scale.x = Random.Range(5, 10);
		Scale.y = Random.Range(5, 10);
		Scale.z = 0.0001f;
		return Scale;
	}

	private IEnumerator LateCall() {
    	yield return new WaitForSeconds(10);
    	rb.velocity = Vector2.zero;
      gameObject.SetActive(false);
   }

}