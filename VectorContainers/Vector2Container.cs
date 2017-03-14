using UnityEngine;

namespace OptimizationTools
{
  public class Vector2Container 
  {
    public Vector2 Vector;

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

    public void Set (ref Vector2 v) 
    {
      MVector.Set(ref Vector, ref v);
    }

    public void Set (Vector2Container v)
    {
      Set(ref v.Vector);
    }

    public void Set (float x, float y)
    {
      MVector.Set(ref Vector, x, y);
    }

    #endregion

    #region Add Methods

    public void Add (ref Vector2 v) 
    {
      MVector.AddTo(ref Vector, ref v);
    }

    public void Add (Vector2Container v) 
    {
      Add(ref v.Vector);
    }

    public static Vector2Container operator +(Vector2Container v1, Vector2Container v2)
    {
      Vector2Container result = Pool<Vector2Container>.GetTemporalIfFunctionEnabled();
      MVector.AddTo(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Subtraction Methods

    public void Subtract (ref Vector2 v) 
    {
      MVector.RemoveFrom(ref Vector, ref v);
    }

    public void Subtract (Vector2Container v) 
    {
      Subtract(ref v.Vector);
    }

    public static Vector2Container operator -(Vector2Container v1, Vector2Container v2)
    {
      Vector2Container result = Pool<Vector2Container>.GetTemporalIfFunctionEnabled();
      MVector.RemoveFrom(ref v1.Vector, ref v2.Vector, ref result.Vector);
      return result;
    }

    #endregion

    #region Scalar Product Methods

    public void MultiplyBy (float scalar) {
      MVector.ScalarProduct(ref Vector, scalar);
    }

    public static Vector2Container operator * (Vector2Container v, float scalar) 
    {
      Vector2Container result = Pool<Vector2Container>.GetTemporalIfFunctionEnabled();
      MVector.ScalarProduct(ref v.Vector, scalar, ref result.Vector);
      return result;
    }

    #endregion
  }
}