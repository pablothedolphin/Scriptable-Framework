using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ScriptableFramework.Tests
{
    public class ListenerResponder : ScriptableObject
    {
        public int responseCount = 0;

        public void FunctionToDelegate ()
        {
            responseCount++;
        }

        public void FunctionToDelegate (int value)
        {
            responseCount += value;
        }
    }
}
