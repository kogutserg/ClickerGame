using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int money;
    public int total_money;
    [SerializeField] Button firstAch;
    [SerializeField] bool isFirst;

    private void OnMouseUpAsButton()
    {
        
    }
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        if (total_money >= 10 && !isFirst == false)
        {
            firstAch.interactable = true;
        } else
        {
            firstAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
    }

    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 10;
        PlayerPrefs.SetInt("money", money);
        isFirst = true;
        PlayerPrefs.SetInt("isFirst", isFirst ? 1 : 0);
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }
}
