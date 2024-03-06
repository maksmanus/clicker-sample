using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BuyItem.asset", menuName = "Itemst/BuyItem", order = 0)]
public class BuyItem : ScriptableObject {
    public enum itemMode
    {
        CLICK, AUTO
    };
    [SerializeField] private itemMode mode;

    public itemMode Mode => mode; 

    [SerializeField] private double price, step;

    [SerializeField] private string decs, itemname;

    [SerializeField] private Button ClickButton;

    public double Step => step;
    public double Price => price; 

    public string Name => itemname;

    public string Desc => decs;
}