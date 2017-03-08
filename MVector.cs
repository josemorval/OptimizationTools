using UnityEngine;

namespace OptimizationUtilities
{
  public static class MVector
  {
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
  }
}
