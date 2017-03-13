using UnityEngine;

namespace OptimizationUtilities {
  public class VectorPoolsManager : MonoBehaviour {

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

      #if OU_POOL_AUTOMATIC_RELEASE
      DontDestroyOnLoad(gameObject);
      #else
      GameObject.Destroy(gameObject);
      #endif
    }

    [System.Diagnostics.Conditional("OU_POOL_AUTOMATIC_RELEASE")]
    void Update () {
      if (vector2PoolSize > 0) {
        Pool<Vector2>.ReleaseTemporalAllocs();
      }
      if (vector3PoolSize > 0) {
        Pool<Vector3>.ReleaseTemporalAllocs();
      }
      if (vector4PoolSize > 0) {
        Pool<Vector4>.ReleaseTemporalAllocs();
      }
    }

    [UnityEditor.Callbacks.DidReloadScripts, System.Diagnostics.Conditional("UNITY_EDITOR")]
    private static void SetExecutionOrder () {
      GameObject go = new GameObject("GO_VectorPool", new System.Type[]{typeof(VectorPoolsManager)});
      UnityEditor.MonoScript monoScript = UnityEditor.MonoScript.FromMonoBehaviour(go.GetComponent<VectorPoolsManager>());
      if (UnityEditor.MonoImporter.GetExecutionOrder(monoScript) > -1000) {
        UnityEditor.MonoImporter.SetExecutionOrder(monoScript, -1000);
      }
      GameObject.DestroyImmediate(go);
    }
  }
}
