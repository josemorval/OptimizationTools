using System.Collections.Generic;
using UnityEngine;

public class VectorContainer<T> {
   public T Vector;

   public VectorContainer() {
      Vector = default(T);
   }
}

public static class MVector
{

	#region Inicializacion del pool de vectores

	public static void Init (int poolSize)
	{
      _poolSize = poolSize;

		_v2referenced = new List<VectorContainer<Vector2>> (poolSize);
		_v2noreferenced = new List<VectorContainer<Vector2>> (poolSize);

		_v3referenced = new List<VectorContainer<Vector3>> (poolSize);
		_v3noreferenced = new List<VectorContainer<Vector3>> (poolSize);

		_v4referenced = new List<VectorContainer<Vector4>> (poolSize);
		_v4noreferenced = new List<VectorContainer<Vector4>> (poolSize);

		for (int i = 0; i < _poolSize; i++) {
			_v2noreferenced.Add (new VectorContainer<Vector2>());
			_v3noreferenced.Add (new VectorContainer<Vector3>());
			_v4noreferenced.Add (new VectorContainer<Vector4>());
		}
			
	}

	#endregion

	#region Region de obtencion de referencias

	//TODO
	//Que pasa cuando nos quedamos sin referencias en el pool

	public static void Get (out VectorContainer<Vector2> v)
	{
		v = _v2noreferenced [0];
		_v2referenced.Add (v);
		_v2noreferenced.RemoveAt (0);
	}

	public static void Get (out VectorContainer<Vector3> v)
	{		
		v = _v3noreferenced [0];
		_v3referenced.Add (v);
		_v3noreferenced.RemoveAt (0);
	}


	public static void Get (out VectorContainer<Vector4> v)
	{
		v = _v4noreferenced [0];
		_v4referenced.Add (v);
		_v4noreferenced.RemoveAt (0);
	}


	public static void Get (out VectorContainer<Vector2> v, float x, float y)
	{
		v = _v2noreferenced [0];
		v.Vector.x = x;
		v.Vector.y = y;
		_v2referenced.Add (v);
		_v2noreferenced.RemoveAt (0);
	}


	public static void Get (out VectorContainer<Vector3> v, float x, float y, float z)
	{
		v = _v3noreferenced [0];
		v.Vector.x = x;
		v.Vector.y = y;
		v.Vector.z = z;
		_v3referenced.Add (v);
		_v3noreferenced.RemoveAt (0);
	}


	public static void Get (out VectorContainer<Vector4> v, float x, float y, float z, float w)
	{		
		v = _v4noreferenced [0];
		v.Vector.x = x;
		v.Vector.y = y;
		v.Vector.z = z;
		v.Vector.w = w;
		_v4referenced.Add (v);
		_v4noreferenced.RemoveAt (0);
	}

	#endregion

	#region Region de liberacion de referencias

	public static void Release (VectorContainer<Vector2> v)
	{
		for (int i = 0; i < _poolSize; i++) {
			if (v == _v2referenced [i]) {
				_v2referenced.RemoveAt (i);
				break;
			}
		}
		_v2noreferenced.Add (v);		
	}

	public static void Release (VectorContainer<Vector3> v)
	{
		for (int i = 0; i < _poolSize; i++) {
			if (v == _v3noreferenced [i]) {
				_v3noreferenced.RemoveAt (i);
				break;
			}
		}
		_v3noreferenced.Add (v);			

	}

	public static void Release (VectorContainer<Vector4> v)
	{
		for (int i = 0; i < _poolSize; i++) {
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

	public static List<VectorContainer<Vector2>> _v2referenced;
	public static List<VectorContainer<Vector2>> _v2noreferenced;

	public static List<VectorContainer<Vector3>> _v3referenced;
	public static List<VectorContainer<Vector3>> _v3noreferenced;

	public static List<VectorContainer<Vector4>> _v4referenced;
	public static List<VectorContainer<Vector4>> _v4noreferenced;

	private static int _poolSize = 10;
}
