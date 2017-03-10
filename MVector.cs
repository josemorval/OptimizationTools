using UnityEngine;

namespace OptimizationUtilities
{
  public enum VectorDimension {
    X, Y, Z, W
  }

  public static class MVector
  {
    #region Asignacion de un valor
    
    public static void Set (out Vector2 v, float x, float y)
    {   
      v.x = x;
      v.y = y;
    }

    public static void Set (out Vector2 storeVector, ref Vector2 referenceVector)
    {   
      storeVector.x = referenceVector.x;
      storeVector.y = referenceVector.y;
    }

    public static void Set (ref Vector2 storeVector, ref Vector2 referenceVector, VectorDimension dimension)
    {   
      switch (dimension) {
        case VectorDimension.X:
          storeVector.x = referenceVector.x;
          break;
        case VectorDimension.Y:
          storeVector.y = referenceVector.y;
          break;
      }
    }
    
    public static void Set (out Vector3 v, float x, float y, float z)
    {   
      v.x = x;
      v.y = y;
      v.z = z;
    }

    public static void Set (out Vector3 storeVector, ref Vector3 referenceVector)
    {   
      storeVector.x = referenceVector.x;
      storeVector.y = referenceVector.y;
      storeVector.z = referenceVector.z;
    }


    public static void Set (ref Vector3 storeVector, ref Vector3 referenceVector, VectorDimension dimension)
    {   
      switch (dimension) {
        case VectorDimension.X:
          storeVector.x = referenceVector.x;
          break;
        case VectorDimension.Y:
          storeVector.y = referenceVector.y;
          break;
        case VectorDimension.Z:
          storeVector.z = referenceVector.z;
          break;
      }
    }

    public static void SetPosition (ref Vector3 storeVector, Transform transform) {
      storeVector.x = transform.position.x;
      storeVector.y = transform.position.y;
      storeVector.z = transform.position.z;
    }

    public static void Set (out Vector4 v, float x, float y, float z, float w)
    {   
      v.x = x;
      v.y = y;
      v.z = z;
      v.w = w;
    }

    public static void Set (out Vector4 storeVector, ref Vector4 referenceVector)
    {   
      storeVector.x = referenceVector.x;
      storeVector.y = referenceVector.y;
      storeVector.z = referenceVector.z;
      storeVector.w = referenceVector.w;
    }

    public static void Set (ref Vector4 storeVector, ref Vector4 referenceVector, VectorDimension dimension)
    {   
      switch (dimension) {
        case VectorDimension.X:
          storeVector.x = referenceVector.x;
          break;
        case VectorDimension.Y:
          storeVector.y = referenceVector.y;
          break;
        case VectorDimension.Z:
          storeVector.z = referenceVector.z;
        break;
        case VectorDimension.W:
          storeVector.w = referenceVector.w;
          break;
      }
    }

    #endregion
    
    #region Operaciones basicas de suma
    
    public static void AddTo (ref Vector2 v1, ref Vector2 v2)
    {
      v1.x = v1.x + v2.x;
      v1.y = v1.y + v2.y;
    }

    public static void AddTo (ref Vector2 v1, ref Vector2 v2, ref Vector2 result)
    {
      result.x = v1.x + v2.x;
      result.y = v1.y + v2.y;
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

    public static void AddTo (ref Vector3 v1, ref Vector3 v2, ref Vector3 result)
    {
      result.x = v1.x + v2.x;
      result.y = v1.y + v2.y;
      result.z = v1.z + v2.z;
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

    public static void AddTo (ref Vector4 v1, ref Vector4 v2, ref Vector4 result)
    {
      result.x = v1.x + v2.x;
      result.y = v1.y + v2.y;
      result.z = v1.z + v2.z;
      result.w = v1.w + v2.w;
    }
    
    public static void AddTo (ref Vector4 v, float x, float y, float z, float w)
    {
      v.x += x;
      v.y += y;
      v.z += z;
      v.w += w;
    }
    
    
    #endregion

    #region Operaciones basicas de resta

    public static void RemoveFrom (ref Vector2 v1, ref Vector2 v2)
    {
      v1.x = v1.x - v2.x;
      v1.y = v1.y - v2.y;
    }

    public static void RemoveFrom (ref Vector2 v1, ref Vector2 v2, ref Vector2 result)
    {
      result.x = v1.x - v2.x;
      result.y = v1.y - v2.y;
    }

    public static void RemoveFrom (ref Vector2 v, float x, float y)
    {
      v.x -= x;
      v.y -= y;
    }

    public static void RemoveFrom (ref Vector3 v1, ref Vector3 v2)
    {
      v1.x = v1.x - v2.x;
      v1.y = v1.y - v2.y;
      v1.z = v1.z - v2.z;
    }

    public static void RemoveFrom (ref Vector3 v1, ref Vector3 v2, ref Vector3 result)
    {
      result.x = v1.x - v2.x;
      result.y = v1.y - v2.y;
      result.z = v1.z - v2.z;
    }

    public static void RemoveFrom (ref Vector3 v, float x, float y, float z)
    {
      v.x -= x;
      v.y -= y;
      v.z -= z;
    }

    public static void RemoveFrom (ref Vector4 v1, ref Vector4 v2)
    {
      v1.x = v1.x - v2.x;
      v1.y = v1.y - v2.y;
      v1.z = v1.z - v2.z;
      v1.w = v1.w - v2.w;
    }

    public static void RemoveFrom (ref Vector4 v1, ref Vector4 v2, ref Vector4 result)
    {
      result.x = v1.x - v2.x;
      result.y = v1.y - v2.y;
      result.z = v1.z - v2.z;
      result.w = v1.w - v2.w;
    }

    public static void RemoveFrom (ref Vector4 v, float x, float y, float z, float w)
    {
      v.x -= x;
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
  }
}
