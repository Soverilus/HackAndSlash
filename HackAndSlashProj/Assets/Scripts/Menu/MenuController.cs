using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {
    float lerpTimer = 0.001f;
    bool isStartingGame = false;
    bool fadeToShop = false;
    bool fadeToCredits = false;
    Vector3 initialMenuScale;
    bool fadeAtAll = true;
    [Header("Main Menu Items")]
    public SpriteRenderer mainMenuArt;
    public SpriteRenderer mainMenuArtTwo;
    public Text[] mainMenuTexts;
    public Image[] mainMenuButtonImages;
    public Button[] mainMenuButtons;

    [Header("Shop Menu Items")]
    public SpriteRenderer shopMenuArt;
    public SpriteRenderer[] shopMenuArtExtras;
    public Text[] shopMenuTexts;
    public Image[] shopMenuButtonImages;
    public Button[] shopMenuButtons;

    [Header("Credits Menu Items")]
    public SpriteRenderer creditMenuArt;
    public Text[] creditMenuTexts;
    public Image[] creditMenuButtonImages;
    public Button[] creditMenuButtons;

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
        for (int i = 0; i < creditMenuTexts.Length; i++) {
            creditMenuTexts[i].color = new Color(creditMenuTexts[i].color.r, creditMenuTexts[i].color.g, creditMenuTexts[i].color.b, 0);
        }
        for (int i = 0; i < creditMenuButtonImages.Length; i++) {
            creditMenuButtonImages[i].color = new Color(creditMenuButtonImages[i].color.r, creditMenuButtonImages[i].color.g, creditMenuButtonImages[i].color.b, 0);
        }
        mainMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, 0);
        shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, 0);
        creditMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, 0);
        FadeShopMenuElements(-1);
        FadeCreditMenuElements(-1);
    }

    private void Update() {
        mainMenuArtTwo.color = mainMenuArt.color;
        for (int i = 0; i < shopMenuArtExtras.Length; i++) {
            shopMenuArtExtras[i].color = shopMenuArt.color;
        }
        if (fadeAtAll) {
            if (fadeToShop) {
                FadeToShop();
            }
            else if (fadeToCredits) {
                FadeToCredits();
            }
            else {
                FadeToMain();
            }
        }
        if (isStartingGame) {
            StartGameUpdate();
        }
    }

    public void SetShop(bool active) {
        //set main menu to non-active
        fadeToShop = active;
    }

    public void SetCredits(bool active) {
        //set main menu to non-active
        fadeToCredits = active;
    }

    public void Main() {
        fadeToShop = false;
        fadeToCredits = false;
    }

    void FadeToMain() {
        if (mainMenuArt.color.a < 1) {
            FadeMainMenuElements(1f);
            FadeShopMenuElements(-1f);
            FadeCreditMenuElements(-1f);
        }
    }
    void FadeToShop() {
        if (shopMenuArt.color.a < 1) {
            FadeMainMenuElements(-1f);
            FadeShopMenuElements(1f);
            FadeCreditMenuElements(-1f);
        }
    }
    void FadeToCredits() {
        FadeMainMenuElements(-1f);
        FadeShopMenuElements(-1f);
        FadeCreditMenuElements(1f);
    }

    void FadeMainMenuElements(float positive) {
        mainMenuArt.color = new Color(mainMenuArt.color.r, mainMenuArt.color.g, mainMenuArt.color.b, mainMenuArt.color.a + positive * Time.unscaledDeltaTime);
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
            mainMenuTexts[i].color = new Color(mainMenuTexts[i].color.r, mainMenuTexts[i].color.g, mainMenuTexts[i].color.b, mainMenuTexts[i].color.a + positive * Time.unscaledDeltaTime);
        }
        for (int i = 0; i < mainMenuButtonImages.Length; i++) {
            mainMenuButtonImages[i].color = new Color(mainMenuButtonImages[i].color.r, mainMenuButtonImages[i].color.g, mainMenuButtonImages[i].color.b, mainMenuButtonImages[i].color.a + positive * Time.unscaledDeltaTime);
        }
    }

    void FadeShopMenuElements(float positive) {
        shopMenuArt.color = new Color(shopMenuArt.color.r, shopMenuArt.color.g, shopMenuArt.color.b, shopMenuArt.color.a + positive * Time.unscaledDeltaTime);
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
            shopMenuTexts[i].color = new Color(shopMenuTexts[i].color.r, shopMenuTexts[i].color.g, shopMenuTexts[i].color.b, shopMenuTexts[i].color.a + positive * Time.unscaledDeltaTime);
        }
        for (int i = 0; i < shopMenuButtonImages.Length; i++) {
            shopMenuButtonImages[i].color = new Color(shopMenuButtonImages[i].color.r, shopMenuButtonImages[i].color.g, shopMenuButtonImages[i].color.b, shopMenuButtonImages[i].color.a + positive * Time.unscaledDeltaTime);
        }
    }

    void FadeCreditMenuElements(float positive) {
        creditMenuArt.color = new Color(creditMenuArt.color.r, creditMenuArt.color.g, creditMenuArt.color.b, creditMenuArt.color.a + positive * Time.unscaledDeltaTime);
        if (positive > 0) {
            for (int i = 0; i < creditMenuButtons.Length; i++) {
                creditMenuButtons[i].gameObject.SetActive(true);
            }
        }
        else {
            for (int i = 0; i < creditMenuButtons.Length; i++) {
                if (creditMenuButtonImages[i].color.a <= 0f) {
                    creditMenuButtons[i].gameObject.SetActive(false);
                }
            }
        }
        for (int i = 0; i < creditMenuTexts.Length; i++) {
            creditMenuTexts[i].color = new Color(creditMenuTexts[i].color.r, creditMenuTexts[i].color.g, creditMenuTexts[i].color.b, creditMenuTexts[i].color.a + positive * Time.unscaledDeltaTime);
        }
        for (int i = 0; i < creditMenuButtonImages.Length; i++) {
            creditMenuButtonImages[i].color = new Color(creditMenuButtonImages[i].color.r, creditMenuButtonImages[i].color.g, creditMenuButtonImages[i].color.b, creditMenuButtonImages[i].color.a + positive * Time.unscaledDeltaTime);
        }
    }


    public void LoadScene(string myScene) {
        SceneManager.LoadScene(myScene);
    }

    public void StartGame() {
        for (int i = 0; i < mainMenuButtons.Length; i++) {
            mainMenuButtons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < shopMenuButtons.Length; i++) {
            shopMenuButtons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < creditMenuButtons.Length; i++) {
            creditMenuButtons[i].gameObject.SetActive(false);
        }
        mainMenuArt.color = new Color(mainMenuArt.color.r, mainMenuArt.color.g, mainMenuArt.color.b, 1f);
        fadeAtAll = false;
        isStartingGame = true;
        initialMenuScale = mainMenuArt.transform.localScale;
    }
    void StartGameUpdate() {
        if (mainMenuArt.transform.localScale.magnitude >= initialMenuScale.magnitude * 30) {
            mainMenuArt.transform.localScale = Vector3.Lerp(mainMenuArt.transform.localScale, new Vector3(32f, 32f, 32f), 1f);
            Invoke("StartGameTrue", 0f);
        }
        else {
            Transform myTransform = mainMenuArt.transform.parent.gameObject.transform;
            float myXPos = myTransform.position.x;
            float myYPos = myTransform.position.y;
            float myZPos = myTransform.position.z;
            mainMenuArt.transform.localScale = Vector3.Lerp(mainMenuArt.transform.localScale, new Vector3(mainMenuArt.transform.localScale.x * 1.5f, mainMenuArt.transform.localScale.y * 1.5f, mainMenuArt.transform.localScale.z * 1.5f), lerpTimer);
            myTransform.position = Vector3.Lerp(myTransform.position, new Vector3(myXPos + 0.00525f, myYPos + 1.5f, myZPos), lerpTimer);
            mainMenuArt.color = Color.Lerp(mainMenuArt.color, new Color(mainMenuArt.color.r, mainMenuArt.color.g, mainMenuArt.color.b, 0f), lerpTimer);
            lerpTimer *= 1.25f;
        }
    }
    void StartGameTrue() {
        SceneManager.LoadScene("GoblinFight");
    }

    public void QuitApp() {
        Application.Quit();
    }
}
