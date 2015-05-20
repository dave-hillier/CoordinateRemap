using UnityEngine;
using System.Collections;

public class TestMapping : MonoBehaviour {

	public Vector3g StartPosition;
	public Vector3g MyGlobalPosition;
	public Vector3g FetchedGlobalPosition;
	public string CurrentGlobalPosition;
	public string GlobalFromTransform;
	public bool Move;

	// Use this for initialization
	void Start () {
		Debug.Log ("Test mapping cube start");
	}
	
	// Update is called once per frame
	void Update () {

		MyGlobalPosition.x = StartPosition.x + (decimal)Mathf.Sin ((float)StartPosition.z*Time.fixedTime/5.0f) * 2.5M;
		MyGlobalPosition.z = StartPosition.z + (decimal)Mathf.Cos ((float)StartPosition.z*Time.fixedTime/5.0f) * 2.5M;

		gameObject.transform.position = MyGlobalPosition; // TODO: something more sensible? 

		CurrentGlobalPosition = MyGlobalPosition.ToString ();
		GlobalFromTransform = gameObject.transform.position.ToString();
	}
}
