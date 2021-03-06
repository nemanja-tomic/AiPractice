﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NatureOfCode
{
	class Util
	{
		public static byte[] ObjectToByteArray(object obj)
		{
			var bf = new BinaryFormatter();
			using (var ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}

		public static T ByteArrayToObject<T>(byte[] arrBytes)
		{
			using (var memStream = new MemoryStream())
			{
				var binForm = new BinaryFormatter();
				memStream.Write(arrBytes, 0, arrBytes.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				var obj = binForm.Deserialize(memStream);
				return (T)obj;
			}
		}
	}
}