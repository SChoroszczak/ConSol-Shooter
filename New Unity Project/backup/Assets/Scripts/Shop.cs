﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private Player player;
    private bullet bullet;
    public bool inShop  = false;
    public GameObject shopUI;

    public Text DMG_Text;
    public int DMG_Price;
    public int DMG;

    public Text Jump_Text;
    public int Jump_Price;
    public int jumpsBoost;

    public Text Speed_Text;
    public int Speed_Price;
    public float speedBoost;

    public bool GamePaused;
    void Start()
    {

        GamePaused = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        DMG_Text.text = "2x DMG\n$" + DMG_Price;
        Jump_Text.text = "Jump+\n$" + Jump_Price;
        Speed_Text.text = "Speed+\n$" + Speed_Price;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && inShop)
        {
            ShopScreeen();
        }
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Player p = hitinfo.GetComponent<Player>();

        if (p != null)
        {
            inShop = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D hitinfo)
    {
        inShop = false;
    }


    /////////////////////////////////////////////////////////////////////
    private void ShopScreeen()
    {
        if (GamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        shopUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        shopUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    ////////////////////////////////////////////////////////  do kupienia
    
    public void UpgradeDMGx2()
    {
        if (player.amountOfMoney >= DMG_Price)
        {
            player.amountOfMoney -= DMG_Price;
            DMG *= 2;
        }

    }

    public void UpgradeJumps()
    {
        if (player.amountOfMoney >= Jump_Price)
        {
            player.amountOfMoney -= Jump_Price;
            player.BonusJumps += jumpsBoost;
        }
    }

    public void UpgradeSpeed()
    {
        if (player.amountOfMoney >= Speed_Price)
        {
            player.amountOfMoney -= Speed_Price;
            player.moveSpeed += speedBoost;
        }
    }

}
