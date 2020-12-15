using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{

	private bool invulnerable = false;
	private Rigidbody2D Asteroidrb;
	public Transform Player;
	public float Force;
	public bool Attack = true;
	public Transform FirePosition;

	private int health = 3;

	private float playerdistance;

	private float MaxDistance = 20f;

	private float cooldown = 1f;

	void Awake() {
		cooldown = Difficulty.CoolDown;
	}

	void FixedUpdate() {

		//rotate the fire position towards player
		FirePosition.right = Player.position - transform.position;

		//disable object is it has no health
		if (health == 0)
			gameObject.SetActive(false);

		//shoot at the player if timer is full and within distance
		if (Attack && distance()) {
			Fire();
			Attack = false;
			StartCoroutine(FireCall());
		}
	}

	//if and asteroid hit this then take damage
	void OnTriggerEnter2D(Collider2D col) {
		if (!invulnerable) {
			health -= 1;
			invulnerable = true;
			StartCoroutine(DamageCall());
		}
	}

	//request an item from the object pool and fire it
	void Fire() {
		GameObject Asteroid = ObjectPooler.SharedInstance.PoolRequest();
		if (Asteroid != null) {
			Asteroidrb = Asteroid.GetComponent<Rigidbody2D>();
			Asteroid.transform.position = FirePosition.position;
			Asteroid.SetActive(true);
			Asteroidrb.AddForce(FirePosition.right * Force);
		}
	}

	//damage cooldown
	private IEnumerator DamageCall() {
   	yield return new WaitForSeconds(1);
 	  	invulnerable = false;
  }

  //cannon cooldown
  private IEnumerator FireCall() {
   	yield return new WaitForSeconds(cooldown);
 	  	Attack = true;
  }

  //calculate and return a bool based on distance
  bool distance() {
   	playerdistance = Vector2.Distance(gameObject.transform.position, Player.position);
   	if (playerdistance <= MaxDistance)
   		return true;
   	else
   		return false;
  }
}