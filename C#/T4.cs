using System;
using System.Collections.Generic;

internal class Program
{
	static void Main(string[] args)
	{
		WriteArray(ArrCalc.GetReverse(ArrCalc.GetPositive(GetRandomArray(10))));
		Console.ReadLine();
	}
	static int[] GetRandomArray(int n)
	{
		int[] arr = new int[n];
		Random random = new Random();
		for (int i = 0; i < arr.Length; i++)
		{
			arr[i] = random.Next(int.MinValue, int.MaxValue);
		}
		return arr;
	}
	static void WriteArray(Array array)
	{
		foreach (var item in array)
		{
			Console.Write(item + " _ ");
		}
	}
	public static class ArrCalc
	{
		public static int[] GetPositive(int[] array)
		{
			List<int> tempList = new List<int>();
			foreach (int i in array)
			{
				if (i > 0)
				{
					tempList.Add(i);
				}
			}
			return tempList.ToArray();
		}

		public static int[] GetReverse(int[] array)
		{
			int[] tempList = new int[array.Length];
			for (int i = array.Length - 1, z = 0; i >= 0; i--, z++)
				tempList[z] = array[i];
			return tempList;
		}
	}
}