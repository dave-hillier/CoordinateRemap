using UnityEngine;
using System.Collections;


public class CoordinateRemap : MonoBehaviour {

	public static Vector3g DesiredLocalOrigin;

	public static Vector3g LocalOrigin;

	public GameObject StaticObject;
	public GameObject PositionedObject;

	// Use this for initialization
	void Start () {
		Debug.Log ("Coord holder start");
		int size = 100;
		int count = 10;
		for (int x = -size; x < size; x += size/count) {
			for (int z = -size; z < size; z += size/count) {
				GameObject.Instantiate(StaticObject, new Vector3(x,0,z), Quaternion.identity);
			}
		}

		var obj1 = (GameObject)GameObject.Instantiate(PositionedObject, new Vector3(0,0,0), Quaternion.identity);
		var obj2 = (GameObject)GameObject.Instantiate(PositionedObject, new Vector3(0,0,0), Quaternion.identity);
		var obj3 = (GameObject)GameObject.Instantiate(PositionedObject, new Vector3(0,0,0), Quaternion.identity);

		var positioned = new [] { obj1, obj2, obj3 };
		decimal i = 0;
		foreach (var obj in positioned) {
			var positionHolder = obj.GetComponent<TestMapping>();
			positionHolder.StartPosition.z = i + 5;
			i += 10;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (!DesiredLocalOrigin.Equals(LocalOrigin)) {
			// Translate all entities
			var sw = new System.Diagnostics.Stopwatch();
			var allObjects = GameObject.FindObjectsOfType<GameObject>();

			var offset = new Vector3((float)(DesiredLocalOrigin.x - LocalOrigin.x),
			                         (float)(DesiredLocalOrigin.y - LocalOrigin.y),
			                         (float)(DesiredLocalOrigin.z - LocalOrigin.z));

			Debug.Log ("Translate all " + allObjects.Length + " by " + offset);
			sw.Start();
			foreach(var obj in allObjects)
			{

				obj.transform.position += offset;// TODO: parenting?
				if (obj.name.Contains("Cam"))
				{
					Debug.Log ("Translating: " + obj.name + " to " + obj.transform.position); 
				}
			}
			sw.Stop();
			Debug.Log("Elapsed " + sw.Elapsed.TotalSeconds);
			LocalOrigin = DesiredLocalOrigin;
		}
	}
}
