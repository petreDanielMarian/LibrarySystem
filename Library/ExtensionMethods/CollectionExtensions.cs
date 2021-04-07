using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ExtensionMethods
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Removes the first element from the list that fulfills the match
        /// </summary>
        /// <param name="list"></param>
        /// <param name="match"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void RemoveFirst<T>(this IList<T> list, Predicate<T> match)
        {
            if (match == null) {
                throw new ArgumentNullException("match");
            }

            T elemToRemove = list.FirstOrDefault(elem => match(elem));
            
            if (elemToRemove != null)
            {
                list.Remove(elemToRemove);
            }
        }
    }
}