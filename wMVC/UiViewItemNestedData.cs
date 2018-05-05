namespace wMVC
{
    public class UiViewItemNestedData<ChildType> : UIViewModel
    {
        public bool expanded;
        public ChildType[] children;
    }
}