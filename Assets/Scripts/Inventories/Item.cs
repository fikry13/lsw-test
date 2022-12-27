using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "LSW Test/Item")]
public class Item: ScriptableObject
{
    public string id;
    public Sprite icon;
    public int price;
    public bool equipable;
    public bool consumable;

    public override bool Equals(object other)
    {
        if (other == null || !(other is Item))
        {
            return false;
        }
        Item otherItem = (Item) other;

        return id == otherItem.id;
    }
}
