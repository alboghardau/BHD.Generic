using System;
namespace BHD.LogsHut.Utils
{
    public static class EnumUtils
    {
        /// <summary>
        /// Gets random element from enum
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <returns>Enum element</returns>
        public static T GetRandomEnumElement<T>()
        {
            var random = new Random();
            var values = Enum.GetValues(typeof(T));
            int index = random.Next(0, values.Length);
            return (T)values.GetValue(index);
        }
    }
}

