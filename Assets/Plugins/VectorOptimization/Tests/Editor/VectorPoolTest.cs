using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class VectorPoolTest {

   [SetUp]
   public void Init () {
      MVector.Init(1);
   }

	[Test]
	public void GetReferenceTest() {

      VectorContainer<Vector2> v;

      MVector.Get(out v);

		Assert.NotNull(v);
	}

   [Test]
   public void GetReferenceWhenExceedCapacityThrowsExceptionTest () {
      VectorContainer<Vector2> v;

      MVector.Get(out v);

      Assert.Throws<System.ArgumentOutOfRangeException>(delegate { MVector.Get(out v); });
   }

   [Test]
   public void ReleaseReferenceTest () {
      VectorContainer<Vector2> v;

      MVector.Get(out v);

      MVector.Release(v);

      Assert.DoesNotThrow(delegate { MVector.Get(out v); });
   }
}
