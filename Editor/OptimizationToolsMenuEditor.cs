using UnityEditor;
using UnityEngine;
using OptimizationTools.Pools;

namespace OptimizationTools.Editor {
  public static class OptimizationToolsMenuEditor {

    [MenuItem ("Optimization Tools/Open Configuration")]
    public static void OpenConfiguration () {
      Selection.activeObject = Configuration.OptimizationToolsConfig.Instance;
    }

    [MenuItem ("Optimization Tools/Create Vector Pools Manager Object")]
    public static void CreateVectorPoolsManager () {
      new GameObject ("VectorPoolsManager", new System.Type[] { typeof (VectorPoolsManager) });
    }
  }
}