using System.Linq;

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
