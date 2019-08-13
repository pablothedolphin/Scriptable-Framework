using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// A collection of properties with values that vary depending on the current platform
	/// </summary>
	public static class Platform
	{
		/// <summary>
		/// Is the current build considered a desktop platform?
		/// </summary>
		public static bool IsDesktop
		{
			get
			{
				switch (Application.platform)
				{
					case RuntimePlatform.WindowsPlayer:
					case RuntimePlatform.WindowsEditor:
					case RuntimePlatform.OSXPlayer:
					case RuntimePlatform.OSXEditor:
					case RuntimePlatform.LinuxPlayer:
					case RuntimePlatform.LinuxEditor:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Is the current build considered a mobile platform?
		/// </summary>
		public static bool IsMobile
		{
			get
			{
				switch (Application.platform)
				{
					case RuntimePlatform.Android:
					case RuntimePlatform.IPhonePlayer:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Is the current build considered a web platform?
		/// </summary>
		public static bool IsWeb
		{
			get
			{
				switch (Application.platform)
				{
					case RuntimePlatform.WebGLPlayer:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Returns either <c>Application.persistentDataPath</c> or <c>Application.streamingAssetsPath</c>
		/// depending on which is appropriate for the platform generally speaking.
		/// </summary>
		public static string FilePath
		{
			get
			{
				switch (Application.platform)
				{
					case RuntimePlatform.Android:
					case RuntimePlatform.IPhonePlayer:
					case RuntimePlatform.WebGLPlayer:
						return Application.persistentDataPath + "/";
					default:
						return Application.streamingAssetsPath + "/";
				}
			}
		}

		/// <summary>
		/// Returns <c>Application.persistentDataPath</c> with a "/" at the end for convenience.
		/// </summary>
		public static string PersistentPath
		{
			get
			{
				return Application.persistentDataPath + "/";
			}
		}
	}
}