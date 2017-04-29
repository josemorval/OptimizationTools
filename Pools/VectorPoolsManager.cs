using UnityEngine;

namespace OptimizationTools.Pools {
  public class VectorPoolsManager : MonoBehaviour {

    [SerializeField]
    private int vector2PoolSize;

    [SerializeField]
    private int vector3PoolSize;

    [SerializeField]
    private int vector4PoolSize;

    void Awake () {
      if (vector2PoolSize > 0) {
        Pool<Vector2Container>.Init (vector2PoolSize);
      }
      if (vector3PoolSize > 0) {
        Pool<Vector3Container>.Init (vector3PoolSize);
      }
      if (vector4PoolSize > 0) {
        Pool<Vector4Container>.Init (vector4PoolSize);
      }

#if OT_POOL_AUTOMATIC_RELEASE
      DontDestroyOnLoad (gameObject);
#else
      GameObject.Destroy(gameObject);
#endif
    }

#if OT_POOL_AUTOMATIC_RELEASE

    void Update () {
      if (vector2PoolSize > 0) {
        Pool<Vector2Container>.ReleaseTemporalAllocs ();
      }
      if (vector3PoolSize > 0) {
        Pool<Vector3Container>.ReleaseTemporalAllocs ();
      }
      if (vector4PoolSize > 0) {
        Pool<Vector4Container>.ReleaseTemporalAllocs ();
      }
    }

#endif

#if UNITY_EDITOR && OT_POOL_AUTOMATIC_RELEASE

    [UnityEditor.Callbacks.DidReloadScripts]
    private static void SetExecutionOrder () {
      GameObject go = new GameObject ("GO_VectorPool", new System.Type[] { typeof (VectorPoolsManager) });
      UnityEditor.MonoScript monoScript = UnityEditor.MonoScript.FromMonoBehaviour (go.GetComponent<VectorPoolsManager> ());
      if (UnityEditor.MonoImporter.GetExecutionOrder (monoScript) > -1000) {
        UnityEditor.MonoImporter.SetExecutionOrder (monoScript, -1000);
      }
      GameObject.DestroyImmediate (go);
    }

#endif
  }
}
