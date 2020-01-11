// =======================================================================================
// Tools
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace wovencode
{
	
	// ===================================================================================
	// Tools
	// ===================================================================================
	public partial class Tools
	{
	
		protected const char 	CONST_DELIMITER 	= ';';
		protected const int 	MIN_LENGTH_NAME		= 4;
		protected const int 	MAX_LENGTH_NAME 	= 16;
		
		protected const int		MIN_VALUE_TOKEN		= 1000;
		protected const int		MAX_VALUE_TOKEN		= 9999;
	
		protected static string sOldChecksum, sNewChecksum	= "";
	
		// ============================ PATH & DIRECTORIES ===============================
		
		// -------------------------------------------------------------------------------
		// SetPath
		// -------------------------------------------------------------------------------
		public static string GetPath(string fileName) {
#if UNITY_EDITOR
        	return Path.Combine(Directory.GetParent(Application.dataPath).FullName, fileName);
#elif UNITY_ANDROID
        	return Path.Combine(Application.persistentDataPath, fileName);
#elif UNITY_IOS
        	return Path.Combine(Application.persistentDataPath, fileName);
#else
        	return Path.Combine(Application.dataPath, fileName);
#endif			
		}
		
		// ================================= SECURITY ====================================
		
		// -------------------------------------------------------------------------------
		// GetChecksum
		// -------------------------------------------------------------------------------
		public static bool GetChecksum(string filepath)
		{
			
			sNewChecksum = CalculateMD5(filepath);
		
			sOldChecksum = PlayerPrefs.GetString("CS", "");
			
			if (string.IsNullOrWhiteSpace(sOldChecksum))
				SetChecksum(filepath);
			
			return (sOldChecksum == sNewChecksum);
			
		}
		
		// -------------------------------------------------------------------------------
		// SetChecksum
		// -------------------------------------------------------------------------------
		public static void SetChecksum(string filepath)
		{
			sNewChecksum = CalculateMD5(filepath);
			PlayerPrefs.SetString("CS", sNewChecksum);
		}
		
		// -------------------------------------------------------------------------------
		// CalculateMD5
		// not recommended on very large files
		// -------------------------------------------------------------------------------
		public static string CalculateMD5(string filepath)
		{
			using (var md5 = MD5.Create())
			{
				using (var stream = File.OpenRead(filepath))
				{
					var hash = md5.ComputeHash(stream);
					return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
				}
			}
		}
		
		// ================================= OTHER =======================================
		
		// -------------------------------------------------------------------------------
		// Returns the name of the passed method
		// -------------------------------------------------------------------------------
		public static string GetMethodName(Func<IEnumerator> method)
		{
			return method.Method.Name;
		}
		
		// -------------------------------------------------------------------------------
		// GetUserId
		// -------------------------------------------------------------------------------
		public static string GetUserId
		{
			get
			{
				return SystemInfo.deviceUniqueIdentifier.ToString();
			}
		}
		
		// ============================== VALIDATION =====================================
		
		// -------------------------------------------------------------------------------
		// Validates a name by simply checking length and allowed characters
		// Could be expanded here if required
		// -------------------------------------------------------------------------------
		public static bool IsAllowedName(string _text)
		{
			return _text.Length >= MIN_LENGTH_NAME && 
					_text.Length <= MAX_LENGTH_NAME &&
					Regex.IsMatch(_text, @"^[a-zA-Z0-9_]+$");
		}
	
		// -------------------------------------------------------------------------------
		// Very simple password validation (must not be empty) so it works with hashed
		// passwords as well.
		// Could be expanded here if required
		// -------------------------------------------------------------------------------
		public static bool IsAllowedPassword(string _text)
		{
			return !String.IsNullOrWhiteSpace(_text);
		}
		
		// -------------------------------------------------------------------------------
		// Very simple numeric token validation
		// -------------------------------------------------------------------------------
		public static bool IsAllowedToken(int _token)
		{
			return _token >= MIN_VALUE_TOKEN && _token <= MAX_VALUE_TOKEN;
		}
		
		// -------------------------------------------------------------------------------
		// Very simple numeric token generation (4 digit code from 1000 to 9999)
		// -------------------------------------------------------------------------------
		public static int GenerateToken()
		{
			return UnityEngine.Random.Range(MIN_VALUE_TOKEN, MAX_VALUE_TOKEN);
		}
		
		// -------------------------------------------------------------------------------
		public static string PBKDF2Hash(string text, string salt)
		{
			byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
			Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(text, saltBytes, 10000);
			byte[] hash = pbkdf2.GetBytes(20);
			return BitConverter.ToString(hash).Replace("-", string.Empty);
		}
		
		// ============================== CONVERSION =====================================
		
		// -------------------------------------------------------------------------------
		// ConvertToUnixTimestamp
		// -------------------------------------------------------------------------------
		public static double ConvertToUnixTimestamp(DateTime date)
		{
			DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			TimeSpan diff = date.ToUniversalTime() - origin;
			return Math.Floor(diff.TotalSeconds);
		}
		
		// -------------------------------------------------------------------------------
		// IntArrayToString
		// -------------------------------------------------------------------------------
		public static string IntArrayToString(int[] array)
		{
			if (array == null || array.Length == 0) return null;
			string arrayString = "";
			for (int i = 0; i < array.Length; i++)
			{
				arrayString += array[i].ToString();
				if (i < array.Length - 1)
					arrayString += CONST_DELIMITER;
			}
			return arrayString;
		}

		// -------------------------------------------------------------------------------
		// IntStringToArray
		// -------------------------------------------------------------------------------
		public static int[] IntStringToArray(string array)
		{
			if (string.IsNullOrWhiteSpace(array)) return null;
			string[] tokens = array.Split(CONST_DELIMITER);
			int[] arrayInt = Array.ConvertAll<string, int>(tokens, int.Parse);
			return arrayInt;
		}

		// -------------------------------------------------------------------------------
		// ArrayContains (int)
		// -------------------------------------------------------------------------------
		public static bool ArrayContains(int[] array, int number)
		{
			foreach (int element in array)
			{
				if (element == number)
					return true;
			}
			return false;
		}

		// -------------------------------------------------------------------------------
		// ArrayContains (string)
		// -------------------------------------------------------------------------------
		public static bool ArrayContains(string[] array, string text)
		{
			foreach (string element in array)
			{
				if (element == text)
					return true;
			}
			return false;
		}

		// -------------------------------------------------------------------------------
		// RemoveFromArray (string)
		// -------------------------------------------------------------------------------
		public static string[] RemoveFromArray(string[] array, string text)
		{
			return array.Where(x => x != text).ToArray();
		}
	
		// -------------------------------------------------------------------------------
		// RemoveFromArray (int)
		// -------------------------------------------------------------------------------
		public static int[] RemoveFromArray(int[] array, int number)
		{
			return array.Where(x => x != number).ToArray();
		}
	
		// -------------------------------------------------------------------------------
	}

}

// =======================================================================================