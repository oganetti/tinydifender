using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{


    int moneyAmount;

    public Text money;
    public GameObject bomb;
    public new Renderer renderer;

    public Text buttonGreen;
    public Text buttonBlue;
    public Text buttonRed;
    public Text buttonMagenta;


    // Start is called before the first frame update
    void Start()
    {      

        moneyAmount = PlayerPrefs.GetInt("money");

        moneyAmount = PlayerPrefs.GetInt("money");
        money.text = moneyAmount.ToString();
        renderer = bomb.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //buyColor(PlayerPrefs.GetString("currentColor"));

        moneyAmount = PlayerPrefs.GetInt("money");
        money.text = moneyAmount.ToString();


        if (PlayerPrefs.GetInt("magenta") == 1)
        {
            buttonMagenta.text = "Sold!";
        }
        if (PlayerPrefs.GetInt("red") == 1)
        {
            buttonRed.text = "Sold!";
        }
        if (PlayerPrefs.GetInt("blue") == 1)
        {
            buttonBlue.text = "Sold!";
        }
        if (PlayerPrefs.GetInt("green") == 1)
        {
            buttonGreen.text = "Sold!";
        }
    }


    public void buyColor(string color)
    {

        money.text = moneyAmount.ToString();

        if (PlayerPrefs.GetInt(color) == 0)
        {
            if (PlayerPrefs.GetInt("money") >= 2000)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 2000);
                moneyAmount = PlayerPrefs.GetInt("money");
                

                if (color == "magenta")
                {
                    renderer.sharedMaterial.color = Color.magenta;
                    buttonMagenta.text = "Sold!";
                }
                else if (color == "red")
                {
                    renderer.sharedMaterial.color = Color.red;
                    buttonRed.text = "Sold!";
                }
                else if (color == "green")
                {
                    renderer.sharedMaterial.color = Color.green;
                    buttonGreen.text = "Sold!";
                }
                else if (color == "blue")
                {
                    renderer.sharedMaterial.color = Color.blue;
                    buttonBlue.text = "Sold!";
                }
                else if (color == "magenta")
                {
                    renderer.sharedMaterial.color = Color.magenta;
                    buttonMagenta.text = "Sold!";
                }
                else if(color == "black")
                {
                    renderer.sharedMaterial.color = Color.black;
                }


                PlayerPrefs.SetString("currentColor", color);
                PlayerPrefs.SetInt(color, 1);
            }
        }

        else if (PlayerPrefs.GetInt(color) == 1)
        {
            Debug.Log("Hello theere");
            Debug.Log(PlayerPrefs.GetInt(color) + "");
            if (color == "magenta")
            {
                renderer.sharedMaterial.color = Color.magenta;
            }
            else if (color == "red")
            {
                renderer.sharedMaterial.color = Color.red;
            }
            else if (color == "green")
            {
                renderer.sharedMaterial.color = Color.green;
            }
            else if (color == "blue")
            {
                renderer.sharedMaterial.color = Color.blue;
            }


        }
        }
    }

