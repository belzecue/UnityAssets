﻿
using UnityEngine;

using Bonsai.Core;
using Bonsai.Designer;

namespace Bonsai.Standard
{
    /// <summary>
    /// Compares two values from the blackboard.
    /// </summary>
    [NodeEditorProperties("Conditional/", "Condition")]
    public class CompareEntries : ConditionalAbort
    {
        public string key1;
        public string key2;

        [Tooltip("If the comparison should test for inequality")]
        public bool compareInequality = false;

        public override bool Condition()
        {
            Blackboard bb = Blackboard;

            // If any of the keys is non-existant then return false.
            if (!bb.Exists(key1) || !bb.Exists(key2)) {
                return false;
            }

            object val1 = bb.Get(key1);
            object val2 = bb.Get(key2);

            // Use the polymorphic equals so value types are properly tested as well
            // as taking into account custom equality operations.
            bool bResult = val1.Equals(val2);

            return compareInequality ? !bResult : bResult;
        }
    }
}