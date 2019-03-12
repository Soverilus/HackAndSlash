using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour {
    public SpriteRenderer shopMenuArt;
    bool fadeToShop = false;
    bool fadeToCredits = false;
    public Text[] MainMenuTexts;
    public Image[] MainMenuButtonImages;

    private void Start() {
        shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, 0);
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
            shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, shopMenuArt.color.a + 1f * Time.deltaTime);
            FadeMainMenuElements(-1f);
        }
        else {
            //SetPurchaseMenutoActive
        }
    }
    void FadeToMain() {
        if (shopMenuArt.color.a > 0) {
            shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, shopMenuArt.color.a - 1f * Time.deltaTime);
            FadeMainMenuElements(1f);
        }
    }

    void FadeMainMenuElements(float positive) {
        for (int i = 0; i < MainMenuTexts.Length; i++) {
            MainMenuTexts[i].color = new Color(MainMenuTexts[i].color.r, MainMenuTexts[i].color.g, MainMenuTexts[i].color.b, MainMenuTexts[i].color.a + positive * Time.deltaTime);
            MainMenuButtonImages[i].color = new Color(MainMenuButtonImages[i].color.r, MainMenuButtonImages[i].color.g, MainMenuButtonImages[i].color.b, MainMenuButtonImages[i].color.a + positive * Time.deltaTime);
        }
    }
}
