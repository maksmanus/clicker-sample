using UnityEngine;
using UnityEngine.UI;

public class SceneBuyItem : MonoBehaviour {

    private Core core;
    [SerializeField] private BuyItem item;

    [SerializeField] private Button buyButton;

    [SerializeField] private Text nameText, descText, priceText;

    private void Start() {
        nameText.text = item.Name;
        descText.text = item.Desc;
        priceText.text = item.Price.ToString(new Constants().FormatMoney);

        core = FindObjectOfType<Core>();
    }

    public void isClicked()
    {
        if(item.Mode == BuyItem.itemMode.CLICK) core.AddClickStep(item.Price, item.Step);

        if(item.Mode == BuyItem.itemMode.AUTO) core.AddAutoEarnStep(item.Price, item.Step);
    }
}