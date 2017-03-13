using UnityEngine;

namespace OptimizationUtilities
{
  public class Vector4Container 
  {
    public Vector4 Vector;

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

    #endregion

    #region Assignement Methods

    public void Set (ref Vector4 v) 
    {
      MVector.Set(ref Vector, ref v);
    }

    public void Set (Vector4Container v)
    {
      Set(ref v.Vector);
    }

    #endregion

    #region Add Methods

    public void Add (ref Vector4 v) 
    {
      MVector.AddTo(ref Vector, ref v);
    }

    public void Add (Vector4Container v) 
    {
      Add(ref v.Vector);
    }

    public static Vector4Container operator +(Vector4Container v1, Vector4Container v2)
    {
      Vector4Container result = Pool<Vector4Container>.GetTemporalIfFunctionEnabled();
      MVector.AddTo(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Subtraction Methods

    public void Subtract (ref Vector4 v) 
    {
      MVector.RemoveFrom(ref Vector, ref v);
    }

    public void Subtract (Vector4Container v) 
    {
      Subtract(ref v.Vector);
    }

    public static Vector4Container operator -(Vector4Container v1, Vector4Container v2)
    {
      Vector4Container result = Pool<Vector4Container>.GetTemporalIfFunctionEnabled();
      MVector.RemoveFrom(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Scalar Product Methods

    public void MultiplyBy (float scalar) {
      MVector.ScalarProduct(ref Vector, scalar);
    }

    public static Vector4Container operator * (Vector4Container v, float scalar) 
    {
      Vector4Container result = Pool<Vector4Container>.GetTemporalIfFunctionEnabled();
      MVector.ScalarProduct(ref v.Vector, scalar, ref result.Vector);
      return result;
    }

    #endregion
  }
}