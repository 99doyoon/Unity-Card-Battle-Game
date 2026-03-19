using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public int maxEnergy = 3;
    public int currentEnergy;

    public TMP_Text energyText;

    void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        currentEnergy = maxEnergy;
        UpdateUI();
    }

    public bool UseEnergy(int amount)
    {
        if (currentEnergy < amount)
            return false;

        currentEnergy -= amount;
        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        if (energyText != null)
        {
            energyText.text = "Energy : " + currentEnergy;
        }
    }
}