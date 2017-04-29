using System.Collections;
using System.Diagnostics;

namespace OptimizationTools.Pools {
  public static class Pool<T> where T : new() {
    public static void Init (int poolSize) {
      pool = new T[poolSize];
      for (iterator = 0; iterator < poolSize; ++iterator) {
        pool[iterator] = new T ();
      }
      usedElements = new BitArray (poolSize);

#if OT_POOL_AUTOMATIC_RELEASE

      managedElements = new BitArray (poolSize, true);

#endif
    }

    public static T Get () {
      PointIteratorToFreeElementAndAllocIt ();
      return pool[iterator];
    }

    public static T GetTemporalIfFunctionEnabled () {
#if OT_POOL_AUTOMATIC_RELEASE
      return Pool<T>.GetTemporal ();
#else
      return Pool<T>.Get();
#endif
    }

#if OT_POOL_AUTOMATIC_RELEASE

    public static T GetTemporal () {
      PointIteratorToFreeElementAndAllocIt ();
      managedElements.Set (iterator, false);
      return pool[iterator];
    }

    public static void ReleaseTemporalAllocs () {
      usedElements.And (managedElements);
      LogElementReleasedFromPool ();
      managedElements.SetAll (true);
    }

    public static void MarkAsNonTemporalAlloc (T element) {
      PointIteratorToFreeElement ();
      managedElements.Set (iterator, true);
    }

    public static void MarkAsTemporalAlloc (T element) {
      PointIteratorToFreeElement ();
      managedElements.Set (iterator, false);
    }

#endif

    public static void Release (T element) {
      iterator = 0;
      while (!pool[iterator].Equals (element)) { ++iterator; }
      LogElementReleasedFromPool ();
      usedElements.Set (iterator, false);
    }

    private static void PointIteratorToFreeElementAndAllocIt () {
      PointIteratorToFreeElement ();
      usedElements.Set (iterator, true);
      LogElementAllocFromPool ();
    }

    private static void PointIteratorToFreeElement () {
      iterator = 0;
      while (usedElements[iterator]) {
        ++iterator;
        CheckPoolSizeExceeded ();
      }
    }

    [Conditional (Constants.Modes.Safe)]
    private static void CheckPoolSizeExceeded () {
      if (iterator == pool.Length) {

        T[] newPool = new T[pool.Length + 1];
        pool.CopyTo (newPool, 0);
        newPool[newPool.Length - 1] = new T ();
        pool = newPool;

        usedElements.Length += 1;

#if OT_POOL_AUTOMATIC_RELEASE

        managedElements.Length += 1;
        managedElements.Set (managedElements.Length - 1, true);

#endif

        LogPoolResized ();
      }
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogElementAllocFromPool () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Alloc. Used elements = " + UsedElementsCount);
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogElementReleasedFromPool () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Release. Used elements = " + UsedElementsCount);
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogPoolResized () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Resized");
    }

    private static int UsedElementsCount {
      get {
        int count = 0;
        for (int i = 0; i < pool.Length; ++i) {
          if (usedElements[i]) { ++count; }
        }
        return count;
      }
    }

    private static int iterator;
    private static T[] pool;
    private static BitArray usedElements;

#if OT_POOL_AUTOMATIC_RELEASE

    private static BitArray managedElements;

#endif
  }
}
