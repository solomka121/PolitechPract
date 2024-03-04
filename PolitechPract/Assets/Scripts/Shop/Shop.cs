using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private DataPlayer dataPlayer = new DataPlayer();

    public Item tempItem;
    public Item[] allItem;

    public class DataPlayer {
        public int money;

        public List<ItemId> buyItem = new List<ItemId>();
        public int idChoose;
    }


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("Saves"))
        {
            LoadData();
        }
        else
        {
            dataPlayer.money = 1000;
            SaveData();
        }

    }

    private void SaveData() {
        PlayerPrefs.SetString("Saves", JsonUtility.ToJson(dataPlayer));
    }

    private void LoadData()
    {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("Saves"));

        for (int i = 0; i < dataPlayer.buyItem.Count; i++) {
            for (int j = 0; j < allItem.Length; j++) {
                if (allItem[j].id == dataPlayer.buyItem[i]) {
                    allItem[j].isBuy = true;
                }
            }

        }
    }

    public int LoadChoose() {
        return dataPlayer.idChoose;
    }

    public void BuyItem(Item item) {
        if (dataPlayer.money >= item.price && !item.isBuy)
        {
            if(tempItem != null)
                tempItem.isChoose = false;

            dataPlayer.buyItem.Add(item.id);
            dataPlayer.money -= item.price;
            item.isBuy = true;
            item.isChoose = true;
            tempItem = item;

            SaveData();
        }
        else if(item.isBuy)
        {
            tempItem.isChoose = false;
            item.isChoose = true;
            dataPlayer.idChoose = (int)item.id;
            tempItem = item;
            SaveData();
        }
    }
}

public enum ItemId { 
    first,
    second,
    third
}
