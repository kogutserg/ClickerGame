using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int money;
    public int total_money;
    public Text moneyText;

    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        bool isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if (isFirst)
        {
            StartCoroutine(IdleFarm());
        }
    }

    public void ButtonClick()
    {
        money++;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToAchivements()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }
}
