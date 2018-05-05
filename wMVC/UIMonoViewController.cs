using UnityEngine;

namespace wMVC
{
    public class UIMonoViewController : MonoBehaviour
    {
        protected virtual void ViewUpdate()
        {
            if (ComputeConditions())
            {
                UpdateItems();
            }
        }

        private void Start()
        {
            Setup();
        }

        private void Update()
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