using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Automat : Gun
{
    [Space(12)]
    [Header("Automat")]
    [SerializeField] private int numberOfBullets;
    [SerializeField] private TMP_Text bulletsText;
    [SerializeField] private PlayerArmory armory;


    private void UpdateText()
    {
        bulletsText.text = $"Bullets: {numberOfBullets.ToString()}";
    }

    public override void Shot()
    {
        base.Shot();
        numberOfBullets -= 1;
        UpdateText();
        if (numberOfBullets <= 0)
        {
            armory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        bulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        bulletsText.enabled = false;
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        this.numberOfBullets += numberOfBullets;
        UpdateText();
        armory.TakeGunByIndex(1);
    }
}
