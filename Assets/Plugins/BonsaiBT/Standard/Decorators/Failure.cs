﻿
using Bonsai.Core;
using Bonsai.Designer;

namespace Bonsai.Standard
{
    /// <summary>
    /// Alaways returns failure.
    /// </summary>
    [NodeEditorProperties("Decorators/", "SmallCross")]
    public class Failure : Decorator
    {
        public override Status Run()
        {
            return Status.Failure;
        }
    }
}