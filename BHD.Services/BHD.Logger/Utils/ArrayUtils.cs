using System;
namespace BHD.Logger.Utils
{
	public static class ArrayUtils
	{
		/// <summary>
		/// Gets random element from array
		/// </summary>
		/// <typeparam name="T">Obj Type</typeparam>
		/// <param name="array">Array</param>
		/// <returns>Single Obj</returns>
		public static T GetRandomElement<T>(T[] array)
		{
			var random = new Random();
			var index = random.Next(0, array.Length);
			return array[index];
		}
	}
}

