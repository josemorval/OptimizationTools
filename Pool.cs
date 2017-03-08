public static class Pool<T> where T : new()
{
   public static void Init (int poolSize)
   {
      _pool = new T[poolSize];
      for (_iterator = 0; _iterator < poolSize; ++_iterator)
      {
         _pool[_iterator] = new T();
      }
      _usedElements = new System.Collections.BitArray(poolSize);
   }

   public static T Get ()
   {
      _iterator = 0;
      while (_usedElements[_iterator]) { ++_iterator; }
      _usedElements.Set(_iterator, true);
      return _pool[_iterator];
   }

   public static void Release (T element)
   {
      _iterator = 0;
      while (!_pool[_iterator].Equals(element)) { ++_iterator; }
      _usedElements.Set(_iterator, false);
   }

   private static int _iterator;
   private static T[] _pool;
   private static System.Collections.BitArray _usedElements;
}
