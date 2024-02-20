using System;

namespace T3
{
	internal class Program
	{
		static int FindMax(int[] A, int q)
		{
			int i = 0;
			for (int x = 1; x < q; x++)
			{
				if (A[x] > A[i])
				{
					i = x;
				}
			}
			return i;
		}

		static int CountNum(int[] A, int q, int num)
		{
			int count = 0;
			for (int x = 0; x < q; x++)
			{
				if (A[x] == A[num])
				{
					count++;
				}
			}
			return count;
		}

		static int FindNextMax(int[] A, int q, int max)
		{
			int next = 0;
			for (int x = 1; x < q; x++)
			{
				if (A[x] > A[next] && A[x] < A[max])
				{
					next = x;
				}
				else if (A[next] == A[max])
				{
					next = x;
				}
			}
			return next;
		}

		static void Main(string[] args)
		{
			const int q = 20;
			int[] A = new int[q];
			Random random = new Random();
			for (int x = 0; x < q; x++)
			{
				A[x] = random.Next(0, 10);
			}
			int max1, max2, max3;
			max1 = FindMax(A, q);
			int count;
			count = CountNum(A, q, max1);
			if (count > 2)
			{
				max3 = max2 = max1;
			}
			else if (count > 1)
			{
				max2 = max1;
				max3 = FindNextMax(A, q, max2);
			}
			else
			{
				max2 = FindNextMax(A, q, max1);
				count = CountNum(A, q, max2);
				if (count > 1)
				{
					max3 = max2;
				}
				else
				{
					max3 = FindNextMax(A, q, max2);
				}
			}

			Console.WriteLine("Сумма очков трёх команд, занявших первые три места равна " + (A[max1] + A[max2] + A[max3]) + '.');
			Console.ReadLine();
		}
	}
}
