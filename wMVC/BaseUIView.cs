namespace wMVC
{
    public class BaseUIView : UIView<UiViewItemInspectorData> { }

    public class UIView<DataType> : UIView where DataType : UIViewModel
    {
        public DataType data;

        public virtual void Setup(DataType data)
        {
            this.data = data;
            data.item = this;
        }
    }
}