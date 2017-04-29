using UnityEditor;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace OptimizationTools.Tests {
  public class IgnoreWhenIsDefinedAttribute : System.Attribute, ITestAction {
    private readonly string scriptingSymbol;

    public IgnoreWhenIsDefinedAttribute (string scriptingSymbol) {
      this.scriptingSymbol = scriptingSymbol;
    }

    public void BeforeTest (ITest test) {
      string[] currentScriptingSymbols = EditorUserBuildSettings.activeScriptCompilationDefines;

      foreach (string currentScriptingSymbol in currentScriptingSymbols) {
        if (scriptingSymbol == currentScriptingSymbol) {
          Assert.Ignore ("Test ignored when {0} is defined", scriptingSymbol);
          return;
        }
      }
    }

    public void AfterTest (ITest test) { }

    public ActionTargets Targets { get; private set; }
  }
}