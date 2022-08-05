using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMenu : MonoBehaviour
{
    Transform container;
    Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("BuyMenuItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Pistol, "Pistol", Item.GetCost(Item.ItemType.Pistol), 0);
        CreateItemButton(Item.ItemType.Rifle, "Rifle", Item.GetCost(Item.ItemType.Rifle), 1);
    }

    void CreateItemButton(Item.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 60f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.gameObject.SetActive(true);

        shopItemTransform.GetComponent<Button>().onClick.AddListener(delegate { TryBuyItem(itemType); });
    }

    void TryBuyItem(Item.ItemType itemType)
    {
        print("TRYING TO BUY " + itemType.ToString());
    }
}