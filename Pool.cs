using System.Collections;

namespace OptimizationUtilities 
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
    }
    
    public static T Get ()
    {
      _iterator = 0;
      while (_usedElements[_iterator]) 
      { 
        ++_iterator;
        checkPoolSizeExceeded();
      }
      _usedElements.Set(_iterator, true);
      logElementsUsedCount();
      return _pool[_iterator];
    }
    
    public static void Release (T element)
    {
      _iterator = 0;
      while (!_pool[_iterator].Equals(element)) { ++_iterator; }
      _usedElements.Set(_iterator, false);
    }

    [System.Diagnostics.Conditional("OU_SAFE_MODE")]
    private static void checkPoolSizeExceeded () {
      if (_iterator == _pool.Length) {

        T[] newPool = new T[_pool.Length + 1];
        _pool.CopyTo(newPool, 0);
        newPool [newPool.Length - 1] = new T();
        _pool = newPool;

        BitArray newUsedElements = new BitArray(_pool.Length + 1);
        newUsedElements.Or(_usedElements);
        _usedElements = newUsedElements;
      }
    }

    [System.Diagnostics.Conditional("OU_DEBUG_INFO")]
    private static void logElementsUsedCount () {
      int count = 0;
      for (int i = 0; i < _pool.Length; ++i) {
        if (_usedElements[i]) { ++count; }
      }
      UnityEngine.Debug.Log("Pool " + typeof(T).Name + " used elements: " + count);
    }
    
    private static int _iterator;
    private static T[] _pool;
    private static BitArray _usedElements;
  }
}
