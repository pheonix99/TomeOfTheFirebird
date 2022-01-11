using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Helpers
{
    public static class Extensions
    {
        public static T[] RemoveFromArray<T>(this T[] array, T value)
        {
            var list = array.ToList();
            return list.Remove(value) ? list.ToArray() : array;
        }
    }
}
