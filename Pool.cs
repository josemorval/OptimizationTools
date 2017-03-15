using System.Collections;

namespace OptimizationTools 
{
  public static class Pool<T> where T : new()
  {
    public static void Init (int poolSize)
    {
      _pool = new T[poolSize];
      for (_iterator = 0; _iterator < poolSize; ++_iterator)
      {
        _pool[_iterator] = new T();
      }
      _usedElements = new BitArray(poolSize);

      #if OT_POOL_AUTOMATIC_RELEASE

      _managedElements = new BitArray(poolSize, true);

      #endif
    }
    
    public static T Get ()
    {
      PointIteratorToFreeElementAndAllocIt();
      return _pool[_iterator];
    }

    public static T GetTemporalIfFunctionEnabled () {
      #if OT_POOL_AUTOMATIC_RELEASE
      return Pool<T>.GetTemporal();
      #else
      return Pool<T>.Get();
      #endif
    }

    #if OT_POOL_AUTOMATIC_RELEASE

    public static T GetTemporal ()
    {
      PointIteratorToFreeElementAndAllocIt();
      _managedElements.Set(_iterator, false);
      return _pool[_iterator];
    }

    public static void ReleaseTemporalAllocs () 
    {
      _usedElements.And(_managedElements);
      LogElementReleasedFromPool();
      _managedElements.SetAll(true);
    }

    public static void MarkAsNonTemporalAlloc (T element)
    {
      PointIteratorToFreeElement();
      _managedElements.Set(_iterator, true);
    }

    public static void MarkAsTemporalAlloc (T element)
    {
      PointIteratorToFreeElement();
      _managedElements.Set(_iterator, false);
    }

    #endif
    
    public static void Release (T element)
    {
      _iterator = 0;
      while (!_pool[_iterator].Equals(element)) { ++_iterator; }
      LogElementReleasedFromPool();
      _usedElements.Set(_iterator, false);
    }

    private static void PointIteratorToFreeElementAndAllocIt () {
      PointIteratorToFreeElement();
      _usedElements.Set(_iterator, true);
      LogElementAllocFromPool();
    }

    private static void PointIteratorToFreeElement () 
    {
      _iterator = 0;
      while (_usedElements[_iterator]) 
      { 
        ++_iterator;
        CheckPoolSizeExceeded();
      }
    }
    
    [System.Diagnostics.Conditional(Constants.Modes.Safe)]
    private static void CheckPoolSizeExceeded () {
      if (_iterator == _pool.Length) {

        T[] newPool = new T[_pool.Length + 1];
        _pool.CopyTo(newPool, 0);
        newPool [newPool.Length - 1] = new T();
        _pool = newPool;

        _usedElements.Length += 1;

        #if OT_POOL_AUTOMATIC_RELEASE

        _managedElements.Length += 1;
        _managedElements.Set(_managedElements.Length - 1, true);

        #endif

        LogPoolResized();
      }
    }

    [System.Diagnostics.Conditional(Constants.Modes.Debug)]
    private static void LogElementAllocFromPool () 
    {
      UnityEngine.Debug.Log("Pool " + typeof(T).Name + " Alloc. Used elements = " + UsedElementsCount);
    }

    [System.Diagnostics.Conditional(Constants.Modes.Debug)]
    private static void LogElementReleasedFromPool () 
    {
      UnityEngine.Debug.Log("Pool " + typeof(T).Name + " Release. Used elements = " + UsedElementsCount);
    }

    [System.Diagnostics.Conditional(Constants.Modes.Debug)]
    private static void LogPoolResized () 
    {
      UnityEngine.Debug.Log("Pool " + typeof(T).Name + " Resized");
    }

    private static int UsedElementsCount
    {
      get
      {
        int count = 0;
        for (int i = 0; i < _pool.Length; ++i) 
        {
          if (_usedElements[i]) { ++count; }
        }
        return count;
      }
    }

    private static int _iterator;
    private static T[] _pool;
    private static BitArray _usedElements;

    #if OT_POOL_AUTOMATIC_RELEASE

    private static BitArray _managedElements;

    #endif
  }
}
