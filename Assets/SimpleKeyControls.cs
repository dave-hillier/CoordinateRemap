using UnityEngine;
using System.Collections;

public class SimpleKeyControls : MonoBehaviour {

	public Vector3g MyGlobalPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MyGlobalPosition.x += (decimal)(Input.GetAxis ("Horizontal") * 0.1);
		MyGlobalPosition.z += (decimal)(Input.GetAxis ("Vertical") * 0.1);

		transform.position = MyGlobalPosition;

		float max = 3.0f;

		if (System.Math.Abs (transform.position.x) > max) {
			CoordinateRemap.DesiredLocalOrigin = new Vector3g(CoordinateRemap.DesiredLocalOrigin.x-(decimal)(transform.position.x),
			                                                  CoordinateRemap.DesiredLocalOrigin.y,
			                                                  CoordinateRemap.DesiredLocalOrigin.z);
		}
		if (System.Math.Abs (transform.position.z) > max) {
			CoordinateRemap.DesiredLocalOrigin = new Vector3g(CoordinateRemap.DesiredLocalOrigin.x,
			                                                  CoordinateRemap.DesiredLocalOrigin.y,
			                                                  CoordinateRemap.DesiredLocalOrigin.z-(decimal)(transform.position.z));
		}
	}
}
