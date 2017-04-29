using System.Diagnostics;

namespace OptimizationTools.Pools {
  public static class OptimizedPool<T> where T : new() {
    public static void Init (int poolSize) {
      pool = new T[poolSize];
      for (iterator = 0; iterator < poolSize; ++iterator) {
        pool[iterator] = new T ();
      }
    }

    public static T Get () {
      CheckPoolSizeExceeded ();
      LogElementAllocFromPool ();
      return pool[--iterator];
    }

    public static void Release (T element) {
      pool[iterator++] = element;
      LogElementReleasedFromPool ();
    }

    [Conditional (Constants.Modes.Safe)]
    private static void CheckPoolSizeExceeded () {
      if (iterator == 0) {
        T[] newPool = new T[pool.Length + 1];
        pool.CopyTo (newPool, 1);
        newPool[0] = new T ();
        pool = newPool;
        iterator = 1;

        LogPoolResized ();
      }
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogElementAllocFromPool () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Alloc. Used elements = " + usedElementsCount);
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogElementReleasedFromPool () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Release. Used elements = " + usedElementsCount);
    }

    [Conditional (Constants.Modes.Debug)]
    private static void LogPoolResized () {
      UnityEngine.Debug.Log ("Pool " + typeof (T).Name + " Resized");
    }

    private static int usedElementsCount {
      get {
        return pool.Length - iterator;
      }
    }

    private static int iterator;
    private static T[] pool;
  }
}
