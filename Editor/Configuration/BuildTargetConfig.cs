using UnityEngine;
using UnityEditor;

namespace OptimizationTools.Editor.Configuration
{
  [System.Serializable]
  public class BuildTargetConfig
  {
    [SerializeField]
    private BuildTargetGroup buildTarget;

    [SerializeField]
    private bool safeModeActive;

    [SerializeField]
    private bool debugModeActive;

    [SerializeField]
    private bool poolAutomaticReleaseActive;

    public BuildTargetGroup BuildTarget {
      get {
        return buildTarget;
      }
    }

    public bool SafeModeActive
    {
      get
      {
        return safeModeActive;
      }
      set
      {
        if (safeModeActive != value)
        {
          safeModeActive = value;
          SetScriptingSymbolActive(OptimizationTools.Constants.Modes.Safe, safeModeActive);
        }
      }
    }

    public bool DebugModeActive 
    {
      get 
      {
        return debugModeActive;
      }
      set 
      {
        if (debugModeActive != value)
        {
          debugModeActive = value;
          SetScriptingSymbolActive(OptimizationTools.Constants.Modes.Debug, debugModeActive);
        }
      }
    }

    public bool PoolAutomaticReleaseActive 
    {
      get 
      {
        return poolAutomaticReleaseActive;
      }
      set 
      {
        if (poolAutomaticReleaseActive != value)
        {
          poolAutomaticReleaseActive = value;
          SetScriptingSymbolActive(OptimizationTools.Constants.Modes.PoolAutomaticRelease, poolAutomaticReleaseActive);
        }
      }
    }

    public BuildTargetConfig (BuildTargetGroup buildTarget)
    {
      this.buildTarget = buildTarget;
    }

    public void Init ()
    {
      string scriptingSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);
      safeModeActive = scriptingSymbols.Contains(OptimizationTools.Constants.Modes.Safe);
      debugModeActive = scriptingSymbols.Contains(OptimizationTools.Constants.Modes.Debug);
      poolAutomaticReleaseActive = scriptingSymbols.Contains(OptimizationTools.Constants.Modes.PoolAutomaticRelease);
    }

    private void SetScriptingSymbolActive (string scriptingSymbol, bool isActive)
    {
      string scriptingSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTarget);
      if (isActive && !scriptingSymbols.Contains(scriptingSymbol))
      {
        scriptingSymbols += ";" + scriptingSymbol;
      }
      else if (!isActive && scriptingSymbols.Contains(scriptingSymbol))
      {
        scriptingSymbols = scriptingSymbols.Replace(scriptingSymbol, "").Trim(new char[]{';'}).Replace(";;", ";");
      }
      PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTarget, scriptingSymbols);
    }
  }
}
