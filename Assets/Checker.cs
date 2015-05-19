using UnityEngine;
using System.Collections;

public class Checker : MonoBehaviour {

	private float dropPoint = 100.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.z > dropPoint) {
			transform.Translate(Vector3.left * 0.005f);
		}
	}

	public void DropToRow(int row) {
		dropPoint = -0.343f + 0.141f * row;

	}
}
