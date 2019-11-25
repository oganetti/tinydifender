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
        PlayerPrefs.SetInt("money", 4000);
        PlayerPrefs.SetInt("green", 0);
        PlayerPrefs.SetInt("blue", 0);
        PlayerPrefs.SetInt("red", 0);
        PlayerPrefs.SetInt("magenta", 0);

        moneyAmount = PlayerPrefs.GetInt("money");
        money.text = moneyAmount.ToString();
        renderer = bomb.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void buyColor(string color)
    {

        if (PlayerPrefs.GetInt(color) == 0)
        {
            if (PlayerPrefs.GetInt("money") >= 2000)
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 2000);
                moneyAmount = PlayerPrefs.GetInt("money");
                money.text = moneyAmount.ToString();

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



                PlayerPrefs.SetInt(color, 1);
            }
        }

        else if (PlayerPrefs.GetInt(color) == 1)
        {
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

