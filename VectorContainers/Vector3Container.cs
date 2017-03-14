using UnityEngine;

namespace OptimizationTools
{
  public class Vector3Container 
  {
    public Vector3 Vector;

    #region Properties

    public float X
    {
      get
      {
        return Vector.x;
      }
      set
      {
        Vector.x = value;
      }
    }

    public float Y
    {
      get
      {
        return Vector.y;
      }
      set
      {
        Vector.y = value;
      }
    }

    public float Z
    {
      get
      {
        return Vector.z;
      }
      set
      {
        Vector.z = value;
      }
    }


    #endregion

    #region Assignement Methods

    public void Set (ref Vector3 v) 
    {
      MVector.Set(ref Vector, ref v);
    }

    public void Set (Vector3Container v)
    {
      Set(ref v.Vector);
    }

    public void Set (float x, float y, float z)
    {
      MVector.Set(ref Vector, x, y, z);
    }

    #endregion

    #region Add Methods

    public void Add (ref Vector3 v) 
    {
      MVector.AddTo(ref Vector, ref v);
    }

    public void Add (Vector3Container v) 
    {
      Add(ref v.Vector);
    }

    public static Vector3Container operator +(Vector3Container v1, Vector3Container v2)
    {
      Vector3Container result = Pool<Vector3Container>.GetTemporalIfFunctionEnabled();
      MVector.AddTo(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Subtraction Methods

    public void Subtract (ref Vector3 v) 
    {
      MVector.RemoveFrom(ref Vector, ref v);
    }

    public void Subtract (Vector3Container v) 
    {
      Subtract(ref v.Vector);
    }

    public static Vector3Container operator -(Vector3Container v1, Vector3Container v2)
    {
      Vector3Container result = Pool<Vector3Container>.GetTemporalIfFunctionEnabled();
      MVector.RemoveFrom(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Scalar Product Methods

    public void MultiplyBy (float scalar) {
      MVector.ScalarProduct(ref Vector, scalar);
    }

    public static Vector3Container operator * (Vector3Container v, float scalar) 
    {
      Vector3Container result = Pool<Vector3Container>.GetTemporalIfFunctionEnabled();
      MVector.ScalarProduct(ref v.Vector, scalar, ref result.Vector);
      return result;
    }

    #endregion
  }
}