using System.Linq;

namespace TomeOfTheFirebird.Helpers
{
    public static class Extensions
    {
        public static T[] RemoveFromArray<T>(this T[] array, T value)
        {
            System.Collections.Generic.List<T> list = array.ToList();
            return list.Remove(value) ? list.ToArray() : array;
        }
    }
}
