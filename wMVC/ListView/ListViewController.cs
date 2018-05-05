using UnityEngine;

namespace wMVC.ListView
{
    public class ListViewController : ListViewController<UiViewItemInspectorData, BaseUIView> { }

    public abstract class ListViewController<DataType, ItemType> : ListViewControllerBase
        where DataType : UIViewModel
        where ItemType : UIView<DataType>
    {
        [Tooltip("Source Data")]
        public DataType[] Datas;

        protected override void UpdateItems()
        {
            for (int i = 0; i < Datas.Length; i++)
            {
                if (i + m_DataOffset < 0)
                {
                    ExtremeLeft(Datas[i]);
                }
                else if (i + m_DataOffset > m_NumItems)
                {
                    ExtremeRight(Datas[i]);
                }
                else
                {
                    ListMiddle(Datas[i], i);
                }
            }
        }

        protected virtual void ExtremeLeft(DataType data)
        {
            RecycleItem(data.template, data.item);
            data.item = null;
        }

        protected virtual void ExtremeRight(DataType data)
        {
            RecycleItem(data.template, data.item);
            data.item = null;
        }

        protected virtual void ListMiddle(DataType data, int offset)
        {
            if (data.item == null)
            {
                data.item = GetItem(data);
            }

            Positioning(data.item.transform, offset);
        }

        protected virtual ItemType GetItem(DataType data)
        {
            if (data == null)
            {
                Debug.LogWarning("Tried to get item with null Data");
                return null;
            }

            if (!m_Templates.ContainsKey(data.template))
            {
                Debug.LogWarning("Cannot get item, template " + data.template + " doesn't exist");
                return null;
            }

            ItemType item = null;
            if (m_Templates[data.template].pool.Count > 0)
            {
                item = (ItemType) m_Templates[data.template].pool[0];
                m_Templates[data.template].pool.RemoveAt(0);

                item.gameObject.SetActive(true);
                item.Setup(data);
            }
            else
            {
                item = Instantiate(m_Templates[data.template].prefab).GetComponent<ItemType>();
                item.transform.parent = transform;
                item.Setup(data);
            }

            return item;
        }
    }
}