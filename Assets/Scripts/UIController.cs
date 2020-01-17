using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Image[] images;
    public int CurrentLevel = 1;
    public GameObject Coin;
    public GameObject quad;
    public Text reward;
    public Text bank;
    int rewardCount;
    void Start()
    {
        images = gameObject.GetComponentsInChildren<Image>();
        UpdateUI();
        
    }
    void UpdateUI()
    {
        if(images.Length >= 4)
        {
            images[0].GetComponentInChildren<Text>().text = CurrentLevel.ToString();
            images[1].GetComponentInChildren<Text>().text = (CurrentLevel + 1).ToString();
            images[2].color = new Color32(255, 255, 255, 255);
            images[3].color = new Color32(255, 255, 255, 255);
        }
    }
    public void CheckPoint1()
    {
        images[2].color = new Color32(255, 127, 0, 255);
    }

    public void CheckPoint2()
    {
        images[3].color = new Color32(255, 127, 0, 255);
    }

    public void OnClick()
    {
        StartCoroutine(CollectCoins());
    }

    public void Coins()
    {
        UpdateUI();
        rewardCount = Random.Range(50, 100);
        reward.text = rewardCount.ToString();
        Coin.SetActive(true);
    }
    IEnumerator CollectCoins()
    {
        int index = 0;
        int Currentbank = int.Parse(bank.text);
        List<GameObject> gameObjects = new List<GameObject>();
        for(int i = int.Parse(reward.text)-1; i>=0; i--)
        {
            if (i % 10 == 0)
            {
                GameObject go = Instantiate(quad, quad.transform.position, Quaternion.identity, gameObject.transform);
                gameObjects.Add(go);
            }
            reward.text = i.ToString();
            index++;
            bank.text = (Currentbank + index).ToString();
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        Coin.SetActive(false);
        foreach(GameObject go in gameObjects)
        {
            Destroy(go);
        }
        yield return null;
    }
}
