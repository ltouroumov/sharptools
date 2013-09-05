using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SharpTools.Utils.Hash
{
	public static class HashUtils
	{
		private static SHA1 sha1 = SHA1.Create();
		//private static MD5 md5 = MD5.Create();

		public static byte[] GetBytes(this string data)
		{
			return UTF8Encoding.UTF8.GetBytes(data);
		}

		public static byte[] Hash(this byte[] data)
		{
			return sha1.ComputeHash(data);
		}

		public static string HexString(this byte[] data)
		{
			return String.Join("", data.Select(b => b.ToString("X2")));
		}
	}
}

