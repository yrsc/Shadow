using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LateUpdate()
	{
		transform.Rotate(Vector3.up,20 * Time.deltaTime,Space.Self);

	}
}
