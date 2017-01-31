using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MVector
{

	#region Inicializacion del pool de vectores

	public static void Init ()
	{

		_v2referenced = new List<Vector2> ();
		_v2noreferenced = new List<Vector2> ();

		_v3referenced = new List<Vector3> ();
		_v3noreferenced = new List<Vector3> ();

		_v4referenced = new List<Vector4> ();
		_v4noreferenced = new List<Vector4> ();

		for (int i = 0; i < _poolSize; i++) {
			_v2noreferenced.Add (Vector2.zero);
			_v3noreferenced.Add (Vector3.zero);
			_v4noreferenced.Add (Vector4.zero);
		}
			
	}

	#endregion

	#region Region de obtencion de referencias

	//TODO
	//Que pasa cuando nos quedamos sin referencias en el pool

	public static void Get (out Vector2 v)
	{
		v = _v2noreferenced [0];
		_v2referenced.Add (v);
		_v2noreferenced.RemoveAt (0);
	}

	public static void Get (out Vector3 v)
	{		
		v = _v3noreferenced [0];
		_v3referenced.Add (v);
		_v3noreferenced.RemoveAt (0);
	}


	public static void Get (out Vector4 v)
	{
		v = _v4noreferenced [0];
		_v4referenced.Add (v);
		_v4noreferenced.RemoveAt (0);
	}


	public static void Get (out Vector2 v, float x, float y)
	{
		v = _v2noreferenced [0];
		v.x = x;
		v.y = y;
		_v2referenced.Add (v);
		_v2noreferenced.RemoveAt (0);
	}


	public static void Get (out Vector3 v, float x, float y, float z)
	{
		v = _v3noreferenced [0];
		v.x = x;
		v.y = y;
		v.z = z;
		_v3referenced.Add (v);
		_v3noreferenced.RemoveAt (0);
	}


	public static void Get (out Vector4 v, float x, float y, float z, float w)
	{		
		v = _v4noreferenced [0];
		v.x = x;
		v.y = y;
		v.z = z;
		v.w = w;
		_v4referenced.Add (v);
		_v4noreferenced.RemoveAt (0);
	}

	#endregion

	#region Region de liberacion de referencias

	public static void Release (Vector2 v)
	{
		for (int i = 0; i < _v2referenced.Count; i++) {
			if (v == _v2referenced [i]) {
				_v2referenced.RemoveAt (i);
				break;
			}
		}
		_v2noreferenced.Add (v);		
	}

	public static void Release (Vector3 v)
	{
		for (int i = 0; i < _v3noreferenced.Count; i++) {
			if (v == _v3noreferenced [i]) {
				_v3noreferenced.RemoveAt (i);
				break;
			}
		}
		_v3noreferenced.Add (v);			

	}

	public static void Release (Vector4 v)
	{
		for (int i = 0; i < _v4noreferenced.Count; i++) {
			if (v == _v4noreferenced [i]) {
				_v4noreferenced.RemoveAt (i);
				break;
			}
		}
		_v4noreferenced.Add (v);			
	}

	#endregion

	#region Asignacion de un valor

	public static void Set (out Vector2 v, float x, float y)
	{		
		v.x = x;
		v.y = y;
	}

	public static void Set (out Vector3 v, float x, float y, float z)
	{		
		v.x = x;
		v.y = y;
		v.z = z;
	}

	public static void Set (out Vector4 v, float x, float y, float z, float w)
	{		
		v.x = x;
		v.y = y;
		v.z = z;
		v.w = w;
	}

	#endregion

	#region Operaciones basicas de suma

	public static void AddTo (ref Vector2 v1, ref Vector2 v2)
	{
		v1.x = v1.x + v2.x;
		v1.y = v1.y + v2.y;
	}

	public static void AddTo (ref Vector2 v, float x, float y)
	{
		v.x += x;
		v.y += y;
	}

	public static void AddTo (ref Vector3 v1, ref Vector3 v2)
	{
		v1.x = v1.x + v2.x;
		v1.y = v1.y + v2.y;
		v1.z = v1.z + v2.z;
	}

	public static void AddTo (ref Vector3 v, float x, float y, float z)
	{
		v.x += x;
		v.y += y;
		v.z += z;
	}

	public static void AddTo (ref Vector4 v1, ref Vector4 v2)
	{
		v1.x = v1.x + v2.x;
		v1.y = v1.y + v2.y;
		v1.z = v1.z + v2.z;
		v1.w = v1.w + v2.w;

	}

	public static void AddTo (ref Vector4 v, float x, float y, float z, float w)
	{
		v.x += x;
		v.y += y;
		v.z += z;
		v.w += w;
	}


	#endregion

	#region Operaciones basicas de multiplicacion

	public static void ScalarProduct (ref Vector2 v, float s)
	{
		v.x *= s;
		v.y *= s;
	}

	public static void ScalarProduct (ref Vector3 v, float s)
	{
		v.x *= s;
		v.y *= s;
		v.z *= s;
	}

	public static void ScalarProduct (ref Vector4 v, float s)
	{
		v.x *= s;
		v.y *= s;
		v.z *= s;
		v.w *= s;
	}

	#endregion


	#region Operaciones basicas de multiplicacion


	#endregion

	public static List<Vector2> _v2referenced;
	public static List<Vector2> _v2noreferenced;

	public static List<Vector3> _v3referenced;
	public static List<Vector3> _v3noreferenced;

	public static List<Vector4> _v4referenced;
	public static List<Vector4> _v4noreferenced;

	private static int _poolSize = 10;
}
