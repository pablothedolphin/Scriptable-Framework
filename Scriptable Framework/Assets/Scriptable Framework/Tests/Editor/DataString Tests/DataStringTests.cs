using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ScriptableFramework;

namespace ScriptableFramework.Tests
{
    public class DataStringTests
    {
		string testString = "test";
		DataString testDataString = "test";

		[Test]
        public void AssignFromString ()
        {
			DataString dataString = testString;

			Assert.True (dataString == testString);
        }

		[Test]
		public void AssignToString ()
		{
			string text = testDataString;

			Assert.True (text == testDataString);
		}

		[Test]
		public void ConvertToString ()
		{
			Assert.True (testDataString.ToString () == testString);
		}
	}
}
