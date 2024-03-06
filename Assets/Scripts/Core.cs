using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Core : MonoBehaviour {
    
    private LoadData data;
    private FileStream file;
    private BinaryFormatter formatter;

    private double currentBalance, clickStep, autoEarnStep;

    private infoUpdater updater;

    [SerializeField] private Text balanceText;

    public double CurrentBalance => currentBalance;
    public double ClickStep => clickStep;
    public double AutoEarnStep => autoEarnStep;

    private IEnumerator updateClicks()
    {
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);

                if (results.Count > 0)
                {
                    // Если Raycast встретил какой-либо UI элемент
                    Debug.Log("Clicked on the UI");
                }
                else
                {
                    // Если Raycast не встретил UI элемент
                    currentBalance += clickStep;
                    updater.updateText();
                    //balanceText.text = "Баланс: " + currentBalance.ToString(new Constants().FormatMoney);
                }
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    private IEnumerator autoSaveGameData()
    {
        while (true)
        {
            saveGameData();
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator startAutoEarn()
    {
        while (true)
        {
            var step = autoEarnStep / 20;
            currentBalance += step;
            updater.updateText();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Start() {
        file = File.Open(new Constants().FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        file.Position = 0;

        formatter = new BinaryFormatter();

        if(file.Length != 0)
        {
            data = (LoadData) formatter.Deserialize(file);
            currentBalance = data.Balance;
            clickStep = data.ClickStep;
            autoEarnStep = data.AutoEarnStep;
        }
        else
        {
            data = new LoadData();
            currentBalance = 0;
            clickStep = new Constants().DefaultClickStep;
            autoEarnStep = 0;
            data.LoadGameData(currentBalance, clickStep, autoEarnStep);
            formatter.Serialize(file, data);
        }

        //balanceText.text = "Баланс: " + currentBalance.ToString(new Constants().FormatMoney);
        updater = FindAnyObjectByType<infoUpdater>();
        //updater.updateText();

        StartCoroutine(nameof(updateClicks));
        StartCoroutine(nameof(autoSaveGameData));
        StartCoroutine(nameof(startAutoEarn));
    } 

    private void OnApplicationQuit()
    {
        saveGameData();
        file.Close();
    } 

    private void saveGameData()
    {
        data.LoadGameData(currentBalance, clickStep, autoEarnStep);
        file.Position = 0;
        formatter.Serialize(file, data);
    }

    private void updateText()
    {
        balanceText.text = "Баланс: " + currentBalance.ToString(new Constants().FormatMoney);
        updater.updateText();
    }

    public void AddClickStep(double price, double step) {
        if(currentBalance >= price)
        {
            currentBalance -= price;
            clickStep += step;
            updateText();
        }
    }

    public void AddAutoEarnStep(double price, double step)
    {
        if(currentBalance >= price)
        {
            currentBalance -= price;
            autoEarnStep += step;
            updateText();
        }
    }
    
}