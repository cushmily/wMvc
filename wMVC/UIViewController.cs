using System;
using UnityEngine;
using Zenject;

namespace wMVC
{
    public abstract class UIViewController : IInitializable, ITickable, IDisposable
    {
        public void Initialize()
        {
            Setup();
        }

        public void Tick()
        {
            ViewUpdate();
        }

        public void Dispose() { }

        protected virtual void ViewUpdate()
        {
            if (ComputeConditions())
            {
                UpdateItems();
            }
        }

        protected virtual void Setup() { }

        protected virtual bool ComputeConditions()
        {
            return true;
        }

        protected virtual void UpdateItems() { }
    }
}