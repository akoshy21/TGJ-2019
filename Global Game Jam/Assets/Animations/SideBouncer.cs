using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SideBouncer : MonoBehaviour
{
	private Vector3 startPos;

	public float Xmod;
	public float Ymod;

	public float XspdMod;

	public float YspdMod;
	// Use this for initialization
	void Start ()
	{
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float xbouncer = transform.position.x *Mathf.Sin(Time.time *XspdMod)*Xmod;
		float ybouncer = transform.position.y *Mathf.Sin(Time.time *YspdMod)*Ymod;
		transform.position = startPos + new Vector3(xbouncer, ybouncer, 0);
	}
}
