using UnityEditor;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace OptimizationTools.Tests {
  public class IgnoreWhenIsNotDefinedAttribute : System.Attribute, ITestAction {
    private readonly string scriptingSymbol;

    public IgnoreWhenIsNotDefinedAttribute (string scriptingSymbol) {
      this.scriptingSymbol = scriptingSymbol;
    }

    public void BeforeTest (ITest test) {
      string[] currentScriptingSymbols = EditorUserBuildSettings.activeScriptCompilationDefines;
      foreach (string currentScriptingSymbol in currentScriptingSymbols) {
        if (scriptingSymbol == currentScriptingSymbol) {
          return;
        }
      }
      Assert.Ignore ("Test ignored when {0} is not defined defined", scriptingSymbol);
    }

    public void AfterTest (ITest test) { }

    public ActionTargets Targets { get; private set; }
  }
}