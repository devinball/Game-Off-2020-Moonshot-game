using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public Transform target;
	public float smooth = 10f;
	public Vector3 Offset;

		void Start() {
			Offset = new Vector3(0,0,0);
		}

		//lerp the camera to player position every frame
    void Update() {
			transform.position = Vector3.Lerp(transform.position, target.position, smooth * Time.deltaTime) + Offset;
		}
}