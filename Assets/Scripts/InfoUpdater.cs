using UnityEngine;
using UnityEngine.UI;

public class infoUpdater : MonoBehaviour {
    private Core core;

    [SerializeField] private Text clickStepText, autoEarnText, balanceText;

    bool isThousand, isMillion, isBillion, isTrillion, isUsually;
    private void Awake() 
    {
        core = FindAnyObjectByType<Core>();
        updateText();
    } 
    

    public void updateText()
    {
        isUsually = core.CurrentBalance < 1000 || core.AutoEarnStep < 1000 || core.ClickStep < 1000;
        isThousand = core.CurrentBalance >= 1000 || core.AutoEarnStep >= 1000 || core.ClickStep >= 1000;
        isMillion = core.CurrentBalance >= 1000000 || core.AutoEarnStep >= 1000000 || core.ClickStep >= 1000000;
        isBillion = core.CurrentBalance >= 1000000000 || core.AutoEarnStep >= 1000000000 || core.ClickStep >= 1000000000;
        isTrillion = core.CurrentBalance >= 1000000000000 || core.AutoEarnStep >= 1000000000000 || core.ClickStep >= 1000000000000;
        
        switch (isUsually)
        {
            case true:
                balanceText.text = "За клик: " + core.CurrentBalance.ToString(new Constants().FormatMoney);
                clickStepText.text = "За клик: " + core.ClickStep.ToString(new Constants().FormatMoney);
                autoEarnText.text = "В секунду: " + core.AutoEarnStep.ToString(new Constants().FormatMoney);
                break;
        }

        switch (isThousand)
        {
            case true:
                if(core.CurrentBalance >= 1000)
                    balanceText.text = "За клик: " + (core.CurrentBalance / 1000).ToString(new Constants().FormatMoney) + " тыс";
                if(core.ClickStep >= 1000)
                    clickStepText.text = "За клик: " + (core.ClickStep / 1000).ToString(new Constants().FormatMoney) + " тыс";
                if(core.AutoEarnStep >= 1000)
                    autoEarnText.text = "В секунду: " + (core.AutoEarnStep / 1000).ToString(new Constants().FormatMoney) + " тыс";
                break;
        }

        switch (isMillion)
        {
            case true:
                if(core.CurrentBalance >= 1000000)
                    balanceText.text = "За клик: " + (core.CurrentBalance / 1000000).ToString(new Constants().FormatMoney) + " млн";
                if(core.ClickStep >= 1000000)
                    clickStepText.text = "За клик: " + (core.ClickStep / 1000000).ToString(new Constants().FormatMoney) + " млн";
                if(core.AutoEarnStep >= 1000000)
                    autoEarnText.text = "В секунду: " + (core.AutoEarnStep / 1000000).ToString(new Constants().FormatMoney) + " млн";
                break;
        }
    }
}