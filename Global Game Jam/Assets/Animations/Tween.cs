using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{

	public Transform sphere, cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//x += (target - x) * .1
		sphere.position += (cube.position - sphere.position) * .1f;
	}
}
