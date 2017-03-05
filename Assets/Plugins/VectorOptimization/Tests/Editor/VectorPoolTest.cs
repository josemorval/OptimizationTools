using UnityEngine;
using NUnit.Framework;

public class VectorPoolTest {

   [SetUp]
   public void Init () {
      Pool<VectorContainer<Vector2>>.Init(1);
   }

	[Test]
	public void GetReferenceTest() {
      VectorContainer<Vector2> v = Pool<VectorContainer<Vector2>>.Get();
		Assert.NotNull(v);
	}

   [Test]
   public void GetReferenceWhenExceedCapacityThrowsExceptionTest () {
      VectorContainer<Vector2> v = Pool<VectorContainer<Vector2>>.Get();
      Assert.Throws<System.ArgumentOutOfRangeException>(delegate { Pool<VectorContainer<Vector2>>.Get(); });
   }

   [Test]
   public void ReleaseReferenceTest () {
      VectorContainer<Vector2> v = Pool<VectorContainer<Vector2>>.Get();
      Pool<VectorContainer<Vector2>>.Release(v);
      Assert.DoesNotThrow(delegate { Pool<VectorContainer<Vector2>>.Get(); });
   }
}
