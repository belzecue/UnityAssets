﻿
using Bonsai.Core;
using Bonsai.Designer;

namespace Bonsai.Standard
{
    /// <summary>
    /// Always returns success.
    /// </summary>
    [NodeEditorProperties("Decorators/", "SmallCheckmark")]
    public class Success : Decorator
    {
        public override Status Run()
        {
            return Status.Success;
        }
    }
}