using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//c# Variables
//c# Functions
//Booleans


public class CubeSpawner : MonoBehaviour {
	public GameObject cubePrefabVar;
	private int delayCount = 0;
	private const int DELAY_TIME = 2;
	private const int MAX_CUBES = 200;
	public static List <GameObject> cubes = new List<GameObject>();
	private float shrinkage = 0.992f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (delayCount <= 0) {
			delayCount = DELAY_TIME;
			GameObject gObj = Instantiate (cubePrefabVar) as GameObject;
			Color color = new Color (Random.value, Random.value, Random.value);
			gObj.GetComponent<Renderer> ().material.color = color;
			cubes.Add (gObj);
		
			List <GameObject> removeList = new List<GameObject> ();
			foreach (GameObject cube in cubes) {
				float scale = cube.transform.localScale.x;
				scale *= this.shrinkage;
				cube.transform.localScale = Vector3.one * scale;
				if (cube.transform.localScale.x < 0.01f) {
					removeList.Add (cube);
				}
			}

			foreach (GameObject cubeToKill in removeList) {
				cubes.Remove (cubeToKill);
				Destroy (cubeToKill);
			}
		}
		delayCount--;
		//cubePrefabVar.GetComponent<Transform> ().position.x = 5;
	}
}
