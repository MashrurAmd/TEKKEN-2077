using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelManager : MonoBehaviour
{
    [Header("Main Panels")]
    public GameObject loadingPanel;   
    public GameObject menuPanel;      

    [Header("Loading Panel Children")]
    public GameObject loadingImage;   
    public Slider loadingBar;         
    public GameObject backgroundImage; 

    [Header("Timings")]
    public float loadingDuration = 5f;     
    public float backgroundDuration = 5f;  

    public GameObject settingsPanel;
    public GameObject infoPanel;

    public GameObject gameDetailsPanel;
    public GameObject gameTermsPanel;
    public GameObject gameRulesPanel;

    public GameObject playerSelectPanel;

    private void Start()
    {

        loadingPanel.SetActive(false);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        infoPanel.SetActive(false);

        gameDetailsPanel.SetActive(false);
        gameTermsPanel.SetActive(false);
        gameDetailsPanel.SetActive(false);
        //playerSelectPanel.SetActive(false);

        StartCoroutine(RunSequence());
    }

    IEnumerator RunSequence()
    {
 
        loadingPanel.SetActive(true);
        loadingImage.SetActive(true);
        loadingBar.gameObject.SetActive(true);
        backgroundImage.SetActive(false);

        float elapsed = 0f;
        while (elapsed < loadingDuration)
        {
            elapsed += Time.deltaTime;
            loadingBar.value = Mathf.Clamp01(elapsed / loadingDuration);
            yield return null;
        }


        loadingImage.SetActive(false);
        loadingBar.gameObject.SetActive(false);
        backgroundImage.SetActive(true);

        yield return new WaitForSeconds(backgroundDuration);


        loadingPanel.SetActive(false);
        menuPanel.SetActive(true);
    }


    public void OpenSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {

        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void OpenInfoPannel()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        infoPanel.SetActive(true);  
    }
    public void CloseInfoPannel()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void OpenGaemDetailsPannel()
    {
        gameDetailsPanel.SetActive(true);   
        infoPanel.SetActive(false);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
        menuPanel.SetActive(false);

    }

    public void CloseGaemDetailsPannel() {
        gameDetailsPanel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void OpenGaemTermsPannel()
    {
        gameTermsPanel.SetActive(true);
        infoPanel.SetActive(false);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
        menuPanel.SetActive(false);
    }
    public void CloseGaemTermsPannel()
    {
        gameTermsPanel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void OpenGaemRulesPannel()
    {
        gameRulesPanel.SetActive(true);
        infoPanel.SetActive(false);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
        menuPanel.SetActive(false);
    }
    public void CloseGaemRulesPannel()
    {
        gameRulesPanel.SetActive(false);
        infoPanel.SetActive(true);
    }


    public void OpenPlayerSelectPannel()
    {
        playerSelectPanel.SetActive(true);
        menuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void ClosePlayerSelectPannel()
    {
        playerSelectPanel.SetActive(false);
        menuPanel.SetActive(true);
    }





}
