﻿using System;
using System.Collections.Generic;

using Bonsai.Core;
using Bonsai.Designer;

namespace Bonsai.Standard
{
    /// <summary>
    /// Returns success if one child returns success.
    /// </summary>
    [NodeEditorProperties("Composites/", "Question")]
    public class Selector : Composite
    {
        public override Status Run()
        {
            // A parent will only receive a Success or Failure, never a Running.
            var status = _iterator.LastStatusReturned;

            // If a child succeeded then the selector succeeds.
            if (status == BehaviourNode.Status.Success) {
                return BehaviourNode.Status.Success;
            }

            // Else child returned failure.

            // Get the next child
            var nextChild = NextChild();

            // If this was the last child then the selector fails.
            if (nextChild == null) {
                return BehaviourNode.Status.Failure;
            }

            // Still need children to process.
            else {
                _iterator.Traverse(nextChild);
                return BehaviourNode.Status.Running;
            }
        }
    }
}