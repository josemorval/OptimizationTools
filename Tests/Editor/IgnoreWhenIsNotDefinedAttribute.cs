using UnityEditor;
using NUnit.Framework;

namespace OptimizationUtilities.Tests
{
  public class IgnoreWhenIsNotDefinedAttribute : System.Attribute, ITestAction
  {
    private readonly string scriptingSymbol;

    public IgnoreWhenIsNotDefinedAttribute (string scriptingSymbol)
    {
      this.scriptingSymbol = scriptingSymbol;
    }

    public void BeforeTest (TestDetails testDetails)
    {
      string[] currentScriptingSymbols = EditorUserBuildSettings.activeScriptCompilationDefines;
      foreach (string currentScriptingSymbol in currentScriptingSymbols)
      {
        if (scriptingSymbol == currentScriptingSymbol)
        {
          return;
        }
      }
      Assert.Ignore("Test ignored when {0} is not defined defined", scriptingSymbol);
    }

    public void AfterTest (TestDetails testDetails) {}

    public ActionTargets Targets { get; private set; }
  }
}