
namespace CommandManager
{
    internal static class Arr
    {

        public static T[] SubArray<T>(this T[] array, int index, int count = int.MaxValue)
        {
            if (index < 0) index = 0;
            if((long)index + (long)count > (long)array.Length) count = array.Length - index;

            T[] result = new T[count];
            for(int i = 0; i < count; i++)
                result[i] = array[i + index];
            return result;
        }

        public static bool ContentEqualsAsIn<T>(this IEnumerable<T> first, IEnumerable<T> second) where T:class
        {
            var fit = first.GetEnumerator();
            var sit = second.GetEnumerator();

            fit.Reset();
            sit.Reset();

            while(fit.MoveNext())
            {
                if (sit.MoveNext() == false) return false;
                if (fit.Current != sit.Current) return false;
            }
            if (sit.MoveNext()) return false;
            else return true;
        }
    }
}
