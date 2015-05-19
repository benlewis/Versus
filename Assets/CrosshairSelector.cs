using UnityEngine;
using System.Collections;

public class CrosshairSelector : MonoBehaviour {

	public Texture2D crosshairTexture;
	public float crosshairScale = 1;

	public Transform selectedColumn;
	public int column = -1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float mid_width = Screen.width / 2.0f;
		float mid_height = Screen.height / 2.0f;

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hitInfo;
		LayerMask layer = LayerMask.GetMask ("Column");
		if (Physics.Raycast (ray, out hitInfo, 100.0f, layer)) {
			//Debug.Log ("Hit " + hitInfo.collider.name);
			selectedColumn.position = hitInfo.transform.position;
			column = int.Parse(hitInfo.transform.name);
			//selectedColumn.renderer.enabled = true;
		} else {
			//selectedColumn.renderer.enabled = false;
			column = -1;
		}

		if (Input.GetMouseButtonDown (0) && column != -1) {

			int row = FindObjectOfType<Board>().DropChecker(column, 1);
			if (row > -1) {
				Checker checker = selectedColumn.GetComponentInChildren<Checker>();

				//Instantiate new Checker
				GameObject newChecker = Instantiate(Resources.Load("BlueChecker", typeof(GameObject))) as GameObject;
				newChecker.transform.parent = selectedColumn;
				newChecker.transform.localScale = checker.transform.localScale;
				newChecker.transform.position = checker.transform.position;
				newChecker.transform.rotation = checker.transform.rotation;

				checker.transform.parent = hitInfo.transform;
				checker.DropToRow(row);
			}


		}

	}


	void OnGUI()
	{
		//if not paused
		if(Time.timeScale != 0)
		{
			if(crosshairTexture!=null)
				GUI.DrawTexture(new Rect((Screen.width-crosshairTexture.width*crosshairScale)/2 ,(Screen.height-crosshairTexture.height*crosshairScale)/2, crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale),crosshairTexture);
			else
				Debug.Log("No crosshair texture set in the Inspector");
		}
	}
}
