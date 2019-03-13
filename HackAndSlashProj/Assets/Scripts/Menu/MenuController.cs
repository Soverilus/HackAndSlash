using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {
    public SpriteRenderer shopMenuArt;
    bool fadeToShop = false;
    bool fadeToCredits = false;
    public Text[] mainMenuTexts;
    public Image[] mainMenuButtonImages;
    public Button[] mainMenuButtons;

    public Text[] shopMenuTexts;
    public Image[] shopMenuButtonImages;
    public Button[] shopMenuButtons;

    private void Start() {
        for (int i = 0; i < mainMenuTexts.Length; i++) {
            mainMenuTexts[i].color = new Color(mainMenuTexts[i].color.r, mainMenuTexts[i].color.g, mainMenuTexts[i].color.b, 0);
        }
        for (int i = 0; i < mainMenuButtonImages.Length; i++) {
            mainMenuButtonImages[i].color = new Color(mainMenuButtonImages[i].color.r, mainMenuButtonImages[i].color.g, mainMenuButtonImages[i].color.b, 0);
        }
        for (int i = 0; i < shopMenuTexts.Length; i++) {
            shopMenuTexts[i].color = new Color(shopMenuTexts[i].color.r, shopMenuTexts[i].color.g, shopMenuTexts[i].color.b, 0);
        }
        for (int i = 0; i < shopMenuButtonImages.Length; i++) {
            shopMenuButtonImages[i].color = new Color(shopMenuButtonImages[i].color.r, shopMenuButtonImages[i].color.g, shopMenuButtonImages[i].color.b, 0);
        }
        shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, 0);
        FadeShopMenuElements(-1);
    }

    private void Update() {
        if (fadeToShop) {
            FadeToShop();
        }
        else if (fadeToCredits) {

        }
        else {
            FadeToMain();
        }
    }

    public void SetShop(bool active) {
        //set main menu to non-active
        fadeToShop = active;
    }

    public void Main() {
        fadeToShop = false;
        fadeToCredits = false;
    }

    void FadeToShop() {
        if (shopMenuArt.color.a < 1) {
            FadeMainMenuElements(-1f);
            FadeShopMenuElements(1f);
        }
        else {
            //SetPurchaseMenutoActive
        }
    }
    void FadeToMain() {
        if (shopMenuArt.color.a > 0 || mainMenuButtonImages[0].color.a < 1) {
            FadeMainMenuElements(1f);
            FadeShopMenuElements(-1f);
        }
    }

    void FadeShopMenuElements(float positive) {
        shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, shopMenuArt.color.a + positive * Time.deltaTime);
        if (positive > 0) {
            for (int i = 0; i < shopMenuButtons.Length; i++) {
                shopMenuButtons[i].gameObject.SetActive(true);
            }
        }
        else {
            for (int i = 0; i < shopMenuButtons.Length; i++) {
                if (shopMenuButtonImages[i].color.a <= 0f) {
                    shopMenuButtons[i].gameObject.SetActive(false);
                }
            }
        }
        for (int i = 0; i < shopMenuTexts.Length; i++) {
            shopMenuTexts[i].color = new Color(shopMenuTexts[i].color.r, shopMenuTexts[i].color.g, shopMenuTexts[i].color.b, shopMenuTexts[i].color.a + positive * Time.deltaTime);
        }
        for (int i = 0; i < shopMenuButtonImages.Length; i++) {
            shopMenuButtonImages[i].color = new Color(shopMenuButtonImages[i].color.r, shopMenuButtonImages[i].color.g, shopMenuButtonImages[i].color.b, shopMenuButtonImages[i].color.a + positive * Time.deltaTime);
        }
    }

    void FadeMainMenuElements(float positive) {
        if (positive > 0) {
            for (int i = 0; i < mainMenuButtons.Length; i++) {
                mainMenuButtons[i].gameObject.SetActive(true);
            }
        }
        else {
            for (int i = 0; i < mainMenuButtons.Length; i++) {
                if (mainMenuButtonImages[i].color.a <= 0f) {
                    mainMenuButtons[i].gameObject.SetActive(false);
                }
            }
        }
        for (int i = 0; i < mainMenuTexts.Length; i++) {
            mainMenuTexts[i].color = new Color(mainMenuTexts[i].color.r, mainMenuTexts[i].color.g, mainMenuTexts[i].color.b, mainMenuTexts[i].color.a + positive * Time.deltaTime);
        }
        for (int i = 0; i < mainMenuButtonImages.Length; i++) {
            mainMenuButtonImages[i].color = new Color(mainMenuButtonImages[i].color.r, mainMenuButtonImages[i].color.g, mainMenuButtonImages[i].color.b, mainMenuButtonImages[i].color.a + positive * Time.deltaTime);
        }
    }
}
