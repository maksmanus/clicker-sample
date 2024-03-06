[System.Serializable]
public class LoadData
{
    private double balance, clickstep, autoearnstep;

    public double Balance => balance;
    public double ClickStep => clickstep;

    public double AutoEarnStep => autoearnstep;

    public void LoadGameData(double Balance, double ClickStep, double AutoEarnStep)
    {
        balance = Balance; clickstep = ClickStep; autoearnstep = AutoEarnStep;
    }
}
