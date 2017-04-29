using NUnit.Framework;
using OptimizationTools.Pools;

namespace OptimizationTools.Tests {
  public class OptimizedPoolTest {
    [SetUp]
    public void Init () {
      OptimizedPool<Vector2Container>.Init (1);
    }

    [Test]
    public void GetReferenceTest () {
      Vector2Container v = OptimizedPool<Vector2Container>.Get ();
      Assert.NotNull (v);
    }

    [Test]
    public void GetReferenceWhenExceedCapacityThrowsExceptionIfSafeModeIsNotActiveTest () {
#if !OT_SAFE_MODE
      OptimizedPool<Vector2Container>.Get ();
      Assert.Throws<System.ArgumentOutOfRangeException> (delegate {
        OptimizedPool<Vector2Container>.Get ();
      });
#else
      Assert.Ignore ("Test ignored on Safe Mode");
#endif
    }

    [Test]
    public void GetReferenceWhenExceedCapacityIncreasePoolSizeInsteadThrowingExceptionTest () {
#if OT_SAFE_MODE
      OptimizedPool<Vector2Container>.Get ();
      Assert.DoesNotThrow (delegate {
        OptimizedPool<Vector2Container>.Get ();
      });
#else
      Assert.Ignore ("Test ignored when Safe Mode is disabled");
#endif
    }

    [Test]
    public void ReleaseReferenceTest () {
      Vector2Container v = OptimizedPool<Vector2Container>.Get ();
      OptimizedPool<Vector2Container>.Release (v);
      Assert.DoesNotThrow (delegate {
        OptimizedPool<Vector2Container>.Get ();
      });
    }
  }
}