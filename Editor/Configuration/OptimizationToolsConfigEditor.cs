using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;
using System.Collections.Generic;

namespace OptimizationTools.Editor.Configuration
{
  [CustomEditor(typeof(OptimizationToolsConfig))]
  public class OptimizationToolsConfigEditor : UnityEditor.Editor 
  {
    public override void OnInspectorGUI ()
    {
      OptimizationToolsConfig config = target as OptimizationToolsConfig;

      _buildTarget = (BuildTargetGroup) EditorGUILayout.EnumPopup("Build Target", _buildTarget);

      BuildTargetConfig targetConfig = config.GetConfigForBuildTarget(_buildTarget);

      targetConfig.DebugModeActive = EditorGUILayout.Toggle("Debug Mode", targetConfig.DebugModeActive);
      targetConfig.SafeModeActive = EditorGUILayout.Toggle("Safe Mode", targetConfig.SafeModeActive);
      targetConfig.PoolAutomaticReleaseActive = EditorGUILayout.Toggle("Pool Automatic Release Mode", targetConfig.PoolAutomaticReleaseActive);
    }

    void OnEnable ()
    {
      _buildTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
    }

    private BuildTargetGroup _buildTarget;
  }
}