using System;

namespace SharpTools.Functional
{
    public static class FuncRightPartialExtensions
    {
				/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 1).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2>
			Partial<T1, T2>(this Func<T1, T2> func, T1 a1)
		{
			return () => func(a1);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T3>
			Partial<T1, T2, T3>(this Func<T1, T2, T3> func, T2 a2)
		{
			return (a1) => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3>
			Partial<T1, T2, T3>(this Func<T1, T2, T3> func, T2 a2, T1 a1)
		{
			return () => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T4>
			Partial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T4>
			Partial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4>
			Partial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T5>
			Partial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T5>
			Partial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T5>
			Partial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5>
			Partial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T6>
			Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T6>
			Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T6>
			Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T6>
			Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T6>
			Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T7>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T6, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7)
		{
			return (a1, a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T8>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T6, T7, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8)
		{
			return (a1, a2, a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T6, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7)
		{
			return (a1, a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T5, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T4, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T3, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T2, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T1, T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 8 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T9>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
			}

	public static class FuncLeftPartialExtensions
    {
				/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 1).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2>
			LeftPartial<T1, T2>(this Func<T1, T2> func, T1 a1)
		{
			return () => func(a1);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3>
			LeftPartial<T1, T2, T3>(this Func<T1, T2, T3> func, T1 a1)
		{
			return (a2) => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3>
			LeftPartial<T1, T2, T3>(this Func<T1, T2, T3> func, T1 a1, T2 a2)
		{
			return () => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4>
			LeftPartial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T1 a1)
		{
			return (a2, a3) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4>
			LeftPartial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T1 a1, T2 a2)
		{
			return (a3) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4>
			LeftPartial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func, T1 a1, T2 a2, T3 a3)
		{
			return () => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T1 a1)
		{
			return (a2, a3, a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T1 a1, T2 a2)
		{
			return (a3, a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return () => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T1 a1)
		{
			return (a2, a3, a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return () => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return () => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return (a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T2, T3, T4, T5, T6, T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T3, T4, T5, T6, T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T4, T5, T6, T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T5, T6, T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T6, T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T7, T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return (a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T8, T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			return (a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 8 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Func<T9>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
			}

	public static class ActionRightPartialExtensions
    {
				/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 1).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1>(this Action<T1> func, T1 a1)
		{
			return () => func(a1);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2>(this Action<T1, T2> func, T2 a2)
		{
			return (a1) => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2>(this Action<T1, T2> func, T2 a2, T1 a1)
		{
			return () => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3>(this Action<T1, T2, T3> func, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3>(this Action<T1, T2, T3> func, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3>(this Action<T1, T2, T3> func, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3>
			Partial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4>
			Partial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3>
			Partial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5>
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4>
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3>
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5, T6>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7)
		{
			return (a1, a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5, T6, T7>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8)
		{
			return (a1, a2, a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5, T6>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7)
		{
			return (a1, a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4, T5>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6)
		{
			return (a1, a2, a3, a4, a5) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3, T4>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6, T5 a5)
		{
			return (a1, a2, a3, a4) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2, T3>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4)
		{
			return (a1, a2, a3) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1, T2>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3)
		{
			return (a1, a2) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T1>
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2)
		{
			return (a1) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 8 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T8 a8, T7 a7, T6 a6, T5 a5, T4 a4, T3 a3, T2 a2, T1 a1)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
			}
	
	public static class ActionLeftPartialExtensions
    {
				/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 1).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1>(this Action<T1> func, T1 a1)
		{
			return () => func(a1);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2>
			LeftPartial<T1, T2>(this Action<T1, T2> func, T1 a1)
		{
			return (a2) => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 2).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2>(this Action<T1, T2> func, T1 a1, T2 a2)
		{
			return () => func(a1, a2);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3>
			LeftPartial<T1, T2, T3>(this Action<T1, T2, T3> func, T1 a1)
		{
			return (a2, a3) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3>
			LeftPartial<T1, T2, T3>(this Action<T1, T2, T3> func, T1 a1, T2 a2)
		{
			return (a3) => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 3).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3>(this Action<T1, T2, T3> func, T1 a1, T2 a2, T3 a3)
		{
			return () => func(a1, a2, a3);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3, T4>
			LeftPartial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T1 a1)
		{
			return (a2, a3, a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3, T4>
			LeftPartial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T1 a1, T2 a2)
		{
			return (a3, a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T4>
			LeftPartial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4) => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 4).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return () => func(a1, a2, a3, a4);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3, T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 a1)
		{
			return (a2, a3, a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3, T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T4, T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T5>
			LeftPartial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5) => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 5).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return () => func(a1, a2, a3, a4, a5);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3, T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3, T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T4, T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T5, T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T6>
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6) => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 6).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return () => func(a1, a2, a3, a4, a5, a6);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3, T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3, T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T4, T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T5, T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T6, T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6, a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T7>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return (a7) => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 7).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 1 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T2, T3, T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1)
		{
			return (a2, a3, a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 2 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T3, T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2)
		{
			return (a3, a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 3 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T4, T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3)
		{
			return (a4, a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 4 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T5, T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4)
		{
			return (a5, a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 5 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T6, T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5)
		{
			return (a6, a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 6 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T7, T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6)
		{
			return (a7, a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 7 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action<T8>
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7)
		{
			return (a8) => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
		/// <summary>
		/// Allows to partially apply a function (applies 8 arguments out of 8).
		/// Right partial application happens in reverse order, meaning that it removes the last parameter of the function.
		/// See LeftPartial for opposite order.
		/// </summary>
		public static Action
			LeftPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> func, T1 a1, T2 a2, T3 a3, T4 a4, T5 a5, T6 a6, T7 a7, T8 a8)
		{
			return () => func(a1, a2, a3, a4, a5, a6, a7, a8);
		}
		
			}

	public static class FuncLeftCurryExtensions
    {
				/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, T3>>
			Curry<T1, T2, T3>(this Func<T1, T2, T3> func)
        {
            return a1 => a2 => func(a1, a2);
        }

		/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, Func<T3, T4>>>
			Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func)
        {
            return a1 => a2 => a3 => func(a1, a2, a3);
        }

		/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>>
			Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func)
        {
            return a1 => a2 => a3 => a4 => func(a1, a2, a3, a4);
        }

		/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, T6>>>>>
			Curry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func)
        {
            return a1 => a2 => a3 => a4 => a5 => func(a1, a2, a3, a4, a5);
        }

		/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, T7>>>>>>
			Curry<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func)
        {
            return a1 => a2 => a3 => a4 => a5 => a6 => func(a1, a2, a3, a4, a5, a6);
        }

		/// <summary>
		/// Allows to curry a function with ordered parameter application.
		/// </summary>
        public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, T8>>>>>>>
			Curry<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func)
        {
            return a1 => a2 => a3 => a4 => a5 => a6 => a7 => func(a1, a2, a3, a4, a5, a6, a7);
        }

		    }

	public static class FuncRightCurryExtensions
    {
				/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T2, Func<T1, T3>>
			ReverseCurry<T1, T2, T3>(this Func<T1, T2, T3> func)
        {
            return a2 => a1 => func(a1, a2);
        }

		/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T3, Func<T2, Func<T1, T4>>>
			ReverseCurry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> func)
        {
            return a3 => a2 => a1 => func(a1, a2, a3);
        }

		/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>>
			ReverseCurry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> func)
        {
            return a4 => a3 => a2 => a1 => func(a1, a2, a3, a4);
        }

		/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T6>>>>>
			ReverseCurry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> func)
        {
            return a5 => a4 => a3 => a2 => a1 => func(a1, a2, a3, a4, a5);
        }

		/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T7>>>>>>
			ReverseCurry<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> func)
        {
            return a6 => a5 => a4 => a3 => a2 => a1 => func(a1, a2, a3, a4, a5, a6);
        }

		/// <summary>
		/// Allows to curry a function with reverse order parameter application.
		/// </summary>
        public static Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T8>>>>>>>
			ReverseCurry<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> func)
        {
            return a7 => a6 => a5 => a4 => a3 => a2 => a1 => func(a1, a2, a3, a4, a5, a6, a7);
        }

		    }

}

