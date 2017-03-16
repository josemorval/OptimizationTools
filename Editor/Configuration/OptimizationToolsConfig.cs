using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections.Generic;

namespace OptimizationTools.Editor.Configuration 
{
  public class OptimizationToolsConfig : ScriptableObject 
  {
    [SerializeField]
    private BuildTargetConfig[] configurationByBuildTarget;

    private static OptimizationToolsConfig instance;

    public static OptimizationToolsConfig Instance
    {
      get
      {
        if (instance == null)
        {
          LoadInstance();
          CheckActiveModes();
        }
        return instance;
      }
    }

    public bool CurrentTargetSafeModeActive
    {
      get
      {
        return GetCurrentConfig().SafeModeActive;
      }
      set
      {
        GetCurrentConfig().SafeModeActive = value;
      }
    }

    public bool CurrentTargetDebugModeActive {
      get 
      {
        return GetCurrentConfig().DebugModeActive;
      }
      set 
      {
        GetCurrentConfig().DebugModeActive = value;
      }
    }

    public bool CurrentTargetPoolAutomaticReleaseActive {
      get 
      {
        return GetCurrentConfig().PoolAutomaticReleaseActive;
      }
      set 
      {
        GetCurrentConfig().PoolAutomaticReleaseActive = value;
      }
    }

    public bool GetDebugModeFor (BuildTargetGroup buildTarget)
    {
      return GetConfigForBuildTarget(buildTarget).DebugModeActive;
    }

    public void SetDebugModeFor (BuildTargetGroup buildTarget, bool isActive)
    {
      GetConfigForBuildTarget(buildTarget).DebugModeActive = isActive;
    }

    public bool GetSafeModeFor (BuildTargetGroup buildTarget)
    {
      return GetConfigForBuildTarget(buildTarget).SafeModeActive;
    }

    public void SetSafeModeFor (BuildTargetGroup buildTarget, bool isActive)
    {
      GetConfigForBuildTarget(buildTarget).SafeModeActive = isActive;
    }

    public bool GetPoolAutomaticReleaseFor (BuildTargetGroup buildTarget)
    {
      return GetConfigForBuildTarget(buildTarget).PoolAutomaticReleaseActive;
    }

    public void SetPoolAutomaticReleaseFor (BuildTargetGroup buildTarget, bool isActive)
    {
      GetConfigForBuildTarget(buildTarget).PoolAutomaticReleaseActive = isActive;
    }

    public BuildTargetConfig GetCurrentConfig () 
    {
      return GetConfigForBuildTarget(EditorUserBuildSettings.selectedBuildTargetGroup);
    }

    public BuildTargetConfig GetConfigForBuildTarget (BuildTargetGroup buildTarget)
    {
      foreach (BuildTargetConfig config in configurationByBuildTarget)
      {
        if (config.BuildTarget == buildTarget)
        {
          return config;
        }
      }
      return null;
    }

    private static void LoadInstance ()
    {
      instance = AssetDatabase.LoadAssetAtPath<OptimizationToolsConfig>(System.IO.Path.Combine(Constants.ConfigSettingsPath, Constants.ConfigSettingsFileName));
      if (instance == null)
      {
        instance = new OptimizationToolsConfig();
        instance.configurationByBuildTarget = new BuildTargetConfig[0];
        if (!AssetDatabase.IsValidFolder(Constants.ConfigSettingsPath))
        {
          AssetDatabase.CreateFolder("Assets", Constants.ConfigSettingsPath.Replace("Assets/", ""));
        }
        AssetDatabase.CreateAsset(instance, System.IO.Path.Combine(Constants.ConfigSettingsPath, Constants.ConfigSettingsFileName));
      }
    }

    private static void CheckActiveModes ()
    {
      List<BuildTargetConfig> buildTargetConfigList = new List<BuildTargetConfig>(instance.configurationByBuildTarget);
      System.Array buildTargetGroups = System.Enum.GetValues(typeof(BuildTargetGroup));
      foreach (BuildTargetGroup buildTargetGroup in buildTargetGroups)
      {
        string scriptingSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
        BuildTargetConfig buildTargetConfig = buildTargetConfigList.Find(config => config.BuildTarget == buildTargetGroup);
        if (buildTargetConfig == null)
        {
          buildTargetConfig = new BuildTargetConfig(buildTargetGroup);
          buildTargetConfigList.Add(buildTargetConfig);
        }
        buildTargetConfig.Init();
      }
      instance.configurationByBuildTarget = buildTargetConfigList.ToArray();
    }
  }
}
