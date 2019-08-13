using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ScriptableFramework;

namespace ScriptableFramework.Tests
{
	public class StringListTests
	{
		StringList strings;
		int listLength = 3;

		[SetUp]
		public void CreateAppEvent ()
		{
			strings = ScriptableObject.CreateInstance<StringList> ();

			for (int i = 0; i < listLength; i++)
			{
				strings.Add ("test");
			}
		}

		[Test]
		public void ToListSize ()
		{
			Assert.True (strings.ToList ().Count == strings.Count);
		}

		[Test]
		public void ToListContent ()
		{
			Assert.True (strings.ToList ()[2] == strings[2]);
		}

		[Test]
		public void ToArraySize ()
		{
			Assert.True (strings.ToArray ().Length == strings.Count);
		}

		[Test]
		public void ToArrayContent ()
		{
			Assert.True (strings.ToArray ()[2] == strings[2]);
		}
	}
}
