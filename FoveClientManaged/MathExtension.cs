using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fove.Managed
{
	internal static class MathExtension
	{
		public const float rad2deg = (float)(180f / Math.PI);
		public const float deg2rad = (float)(Math.PI / 180f);

		public static T Clamp<T>(T value, T min, T max) where T : IComparable
		{
			if (value.CompareTo(min) < 0)
			{
				value = min;
			}
			else if (value.CompareTo(max) > 0)
			{
				value = max;
			}
			return value;
		}
	}
}
