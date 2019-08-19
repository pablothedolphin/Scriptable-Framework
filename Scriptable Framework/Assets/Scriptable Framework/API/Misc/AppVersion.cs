using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableFramework
{
	/// <summary>
	/// Stores the current version of the software being developed. Adhears to Semantic Versioning.
	/// </summary>
    [CreateAssetMenu (menuName = "App Version")]
    public class AppVersion : ScriptableObject
    {
		/// <summary>
		/// The major version number. For versions that should replace a prior major version.
		/// </summary>
		[Header ("Semantic Version")]
		[Min (0)] [SerializeField] private int major = 0;

		/// <summary>
		/// The minor version number. For versions that offer smaller improvements and additions.
		/// </summary>
		[Min (0)] [SerializeField] private int minor = 0;

		/// <summary>
		/// The patch version number. For versions that offer some kind of bug fix or incremental improvements.
		/// </summary>
		[Min (0)] [SerializeField] private int patch = 0;

		/// <summary>
		/// The type of release the software is intended for.
		/// </summary>
		[Header ("Release Suffix")]
		[SearchableEnum] [SerializeField] private ReleaseType release = ReleaseType.Development;

		/// <summary>
		/// If an alpha or beta version, append this number to the end.
		/// </summary>
		[Min (0)] [SerializeField] private int releaseUpdate = 0;

		/// <summary>
		/// Creates a string in the semver format according to the set values in the inspector.
		/// </summary>
		/// <returns>The semver string of the current software being developed.</returns>
		protected virtual string GetVersionNumber ()
		{
			string releaseSuffix = "";

			switch (release)
			{
				case ReleaseType.Development:
					releaseSuffix = "-dev";
					break;
				case ReleaseType.Alpha:
					releaseSuffix = "-a" + releaseUpdate.ToString ();
					break;
				case ReleaseType.Beta:
					releaseSuffix = "-b" + releaseUpdate.ToString ();
					break;
				default:
					break;
			}

			return string.Format ("{0}.{1}.{2}{3}", major, minor, patch, releaseSuffix);
		}

		/// <summary>
		/// Implicitly cast this <c>AppVersion</c>s into a string for display in the UI.
		/// </summary>
		/// <param name="version">The object to cast.</param>
		public static implicit operator string (AppVersion version)
		{
			return version.GetVersionNumber ();
		}

		/// <summary>
		/// Treat this object as a read only string of the current semver.
		/// </summary>
		/// <returns>The semver string.</returns>
		public override string ToString ()
		{
			return GetVersionNumber ();
		}
	}

	/// <summary>
	/// Defines the various types of releases which dictate what sort of suffix is added to the end of the version string.
	/// </summary>
	public enum ReleaseType
	{
		Development,
		Alpha,
		Beta,
		Production
	}
}
