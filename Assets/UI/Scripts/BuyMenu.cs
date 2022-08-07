using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class BuyMenu : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    InputAction openBuyMenu;

    Transform container;
    Transform shopItemTemplate;
    PointsController pointsController;

    WeaponSwitcher weaponSwitcher;

    private void Awake()
    {
        container = transform.Find("container");
        container.gameObject.SetActive(false);
        shopItemTemplate = container.Find("BuyMenuItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        pointsController = GameObject.Find("Player").GetComponent<PointsController>();
        openBuyMenu = input.actions["OpenBuyMenu"];
        weaponSwitcher = GameObject.Find("WeaponController").GetComponent<WeaponSwitcher>();
    }

    private void Start()
    {
        CreateItemButton(Item.ItemType.Pistol, "Pistol", Item.GetCost(Item.ItemType.Pistol), 0);
        CreateItemButton(Item.ItemType.Rifle, "Rifle", Item.GetCost(Item.ItemType.Rifle), 1);
    }

    private void Update()
    {
        if (openBuyMenu.WasPressedThisFrame())
        {
            if (container.gameObject.activeSelf)
            {
                container.gameObject.SetActive(false);
            }
            else if (!container.gameObject.activeSelf)
            {
                container.gameObject.SetActive(true);
            }
        }
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
        print("TRYING TO BUY " + itemType.ToString() + " for " + Item.GetCost(itemType));
        print("Player has " + pointsController.Points + " points");

        weaponSwitcher.AddWeapon(Item.GetPrefab(itemType));

    }
}