using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;


public class Testing : MonoBehaviour
{

	public int poolV2;
	public int poolV3;
	public int poolV4;

	// Use this for initialization
	void Start ()
	{
		MVector.Init (10);			
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {

			Stopwatch sw = new Stopwatch ();
			sw.Start ();
			VectorContainer<Vector3> v1;

			MVector.Get (out v1, 1f, 2f, 3f);

			for (int i = 0; i < 100000; i++) {
				MVector.AddTo (ref v1.Vector, ref v1.Vector);
			}

			MVector.Release (v1);


			sw.Stop ();
			print (sw.Elapsed.TotalMilliseconds);


		}

	}
		

}
	