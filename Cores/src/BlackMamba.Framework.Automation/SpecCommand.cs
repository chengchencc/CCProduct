using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit.Sdk;
using Watcher.Core.Entity;
using StructureMap;
using Watcher.Core;
using BlackMamba.Framework.Core;

namespace BlackMamba.Framework.Automation
{
    public class SpecCommand : TestCommand
    {
        public bool LiveOnly { get; set; }

        public SpecCommand(IMethodInfo method, bool liveOnly)
            : base(method, MethodUtility.GetDisplayName(method), MethodUtility.GetTimeoutParameter(method))
        {
            this.LiveOnly = liveOnly;
        }

        public SpecCommand(IMethodInfo method)
            : this(method, false)
        {
        }

        public override MethodResult Execute(object testClass)
        {
            try
            {
                var currentMode = RegistryModeFactory.GetCurrentMode();

                var shouldProcess = true;

                if (LiveOnly && currentMode != RegistryMode.Live) { shouldProcess = false; }

                if (shouldProcess)
                {
                    var observer = ObjectFactory.GetInstance<IObserver>();
                    if (observer != null)
                    {
                        observer.PopAll();

                        var ret = testMethod.MethodInfo.Invoke(testClass, null);

                        var specItem = ret as SpecItem;
                        if (specItem == null) throw new InvalidOperationException("The function has no return type or the type is not SpecItem!");

                        specItem.ToWatchItem().RunTest(true);

                        if (observer.HasItem)
                        {
                            var failed = observer.Pop().Display();
                            return new FailedResult(testMethod, new Exception(failed), DisplayName);
                        }
                    }
                }
            }
            catch (ParameterCountMismatchException)
            {
                throw new InvalidOperationException("Fact method " + TypeName + "." + MethodName + " cannot have parameters");
            }

            return new PassedResult(testMethod, DisplayName);
        }
    }
}
