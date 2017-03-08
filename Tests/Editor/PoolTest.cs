using UnityEngine;
using NUnit.Framework;
using OptimizationUtilities;

public class PoolTest 
{
  [SetUp]
  public void Init() 
  {
    Pool<Vector2Container>.Init(1);
  }

  [Test]
  public void GetReferenceTest() 
  {
    Vector2Container v = Pool<Vector2Container>.Get();
    Assert.NotNull(v);
  }

  [Test]
  public void GetReferenceWhenExceedCapacityThrowsExceptionTest() 
  {
    Vector2Container v = Pool<Vector2Container>.Get();
    Assert.Throws<System.ArgumentOutOfRangeException>(delegate {
      Pool<Vector2Container>.Get();
    });
  }

  [Test]
  public void ReleaseReferenceTest() 
  {
    Vector2Container v = Pool<Vector2Container>.Get();
    Pool<Vector2Container>.Release(v);
    Assert.DoesNotThrow(delegate {
      Pool<Vector2Container>.Get();
    });
  }
}
