using UnityEngine;

namespace OptimizationUtilities {
  public class VectorPoolsInitializer : MonoBehaviour {
    [SerializeField]
    private int vector2PoolSize;

    [SerializeField]
    private int vector3PoolSize;

    [SerializeField]
    private int vector4PoolSize;

    void Awake () {
      if (vector2PoolSize > 0) {
        Pool<Vector2Container>.Init(vector2PoolSize);
      }
      if (vector3PoolSize > 0) {
        Pool<Vector3Container>.Init(vector3PoolSize);
      }
      if (vector4PoolSize > 0) {
        Pool<Vector4Container>.Init(vector4PoolSize);
      }
    }
  }
}