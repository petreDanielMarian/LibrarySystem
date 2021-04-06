using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static bool TryRemove<T>(this IList<T> list, T element)
        {
            if (list.Contains(element))
            {
                return list.Remove(element);
            }

            return false;
        }
        
        public static void RemoveFirst<T>(this IList<T> list, Predicate<T> match)
        {
            if (match == null) {
                throw new ArgumentNullException("match");
            }

            T elemToRemove = list.First(elem => match(elem));
            list.TryRemove(elemToRemove);
        }
    }
}