using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ScreenState { UI_MAIN=0, BASIC_INFO=1, BEGINNER_TIPS=2, POKEDEX=3, GLOSSARY=4, BATTERY_SAVING=5, TIPS_AND_TRICKS=6};

public class UIManager : MonoBehaviour 
{
	[SerializeField] ScreenState m_currentState;				// determine current screen UI

	[SerializeField] List<GameObject> m_uiPanels;

	[SerializeField] List<GameObject> m_basicPanelButtons;
	[SerializeField] List<GameObject> m_beginnerTipsPanelButtons;
	[SerializeField] List<GameObject> m_pokedexPanelButtons;
	[SerializeField] List<GameObject> m_glossaryPanelButtons;
	[SerializeField] List<GameObject> m_batterySavingPanelButtons;
	[SerializeField] List<GameObject> m_tipsAndTricksPanelButtons;


    // INTRODUCTION TO POKEMON GO BUTTONS
    List<string> m_basicBtnText = new List<string>()
        { 
            "< Back To Home Page", "What is Pokemon Go", "How to Play Pokemon Go",  "12 Quick Starter Guide and Tips", "Getting Started"
        };
    List<string> m_basicUrl = new List<string>()
        { 
            "HOME", "http://lifehacker.com/what-is-pokemon-go-and-why-is-everyone-talking-about-it-1783420761", "http://www.techinsider.io/how-to-play-pokemon-go-2016-7", "https://support.pokemongo.nianticlabs.com/hc/en-us/sections/204863287-Getting-Started"
        };


    // BEGINNER'S GUIDE POKEMON GO
    List<string> m_beginnerBtnText = new List<string>()
        { 
            "< Back To Home Page", "Beginner's Guide", "Beginner's Tips", 
            "Pokemon go Basics", "Catch Pikachu as your Starter Pokemon (with Video)", "Pokemon Go Leveling Tips"
        };
    List<string> m_beginnerUrl = new List<string>()
        { 
            "HOME", "http://www.imore.com/pokemon-go", "http://www.pokemongodb.net/2016/05/pokemon-go-beginners-guide.html", 
            "http://kotaku.com/how-to-play-pokemon-go-1783354400", "http://www.pokemongodb.net/2016/07/get-pikachu-as-your-starter.html", "http://www.pokemongodb.net/p/guides-tips.html"
        };

	// POKDEX PANEL BUTTONS
	List<string> m_pokeDexPanelBtnText = new List<string>()
	{ 
			"< Back To Home Page", "All Pokemon Types", "Bug", "Dark",
			"Dragon", "Electric", "Fighting",
			"Fire", "Flying", "Ghost",
			"Grass", "Ground", "Ice",
			"Poison", "Psychic", "Rock",
			"Steel", "Water"
	};
	List<string> m_pokedexPanelUrl = new List<string>()
	{ 
			"HOME", "https://fevgames.net/pokedex/?type=&sort=0", "https://fevgames.net/pokedex/?type=bug&sort=0", "https://fevgames.net/pokedex/?type=dark&sort=0",
			"https://fevgames.net/pokedex/?type=dragon&sort=0", "https://fevgames.net/pokedex/?type=electric&sort=0", "https://fevgames.net/pokedex/?type=fighting&sort=0",
			"https://fevgames.net/pokedex/?type=fire&sort=0", "https://fevgames.net/pokedex/?type=flying&sort=0", "https://fevgames.net/pokedex/?type=ghost&sort=0",
			"https://fevgames.net/pokedex/?type=grass&sort=0", "https://fevgames.net/pokedex/?type=ground&sort=0", "https://fevgames.net/pokedex/?type=ice&sort=0",
			"https://fevgames.net/pokedex/?type=poison&sort=0", "https://fevgames.net/pokedex/?type=psychic&sort=0", "https://fevgames.net/pokedex/?type=rock&sort=0",
			"https://fevgames.net/pokedex/?type=steel&sort=0", "https://fevgames.net/pokedex/?type=water&sort=0"
	};

    // GLOSSARY PANEL BUTTONS
    List<string> m_glossaryBtnText = new List<string>()
        { 
            "< Back To Home Page", "Official Glossary", "Glossary", 
        };
    List<string> m_glossaryUrl = new List<string>()
        { 
            "HOME", "https://support.pokemongo.nianticlabs.com/hc/en-us/articles/222049307-Glossary", "http://www.pokemongodb.net/2016/05/pokemon-go-glossary.html"
        };
    

	// BATTERY SAVING PANEL BUTTONS
	List<string> m_batterySavingBtnText = new List<string>()
		{ 
			"< Back To Home Page", "9 Best Battery Saving Tips", "Pokemon Go Battery Saver Step by Step Guide", 
            "Enable Battery Saver Mode", "Cut down Data Usage", "Top Best Saver Apps on Android"
		};
	List<string> m_batterySavingUrl = new List<string>()
		{ 
            "HOME", "http://www.pokemongodb.net/2016/04/9-best-battery-saving-tips.html", "http://www.techinsider.io/pokemon-go-battery-saver-mode-2016-7", 
            "http://www.techradar.com/sg/how-to/gaming/how-to-save-the-battery-life-of-your-phone-when-playing-pokemon-go-1324740", "http://bgr.com/2016/07/11/pokemon-go-battery-life-data-usage/", "http://www.androidauthority.com/best-battery-saver-android-apps-266980/"
		};



    // TIPS AND TRICKS PANEL BUTTONS
    List<string> m_tipsAndTricksBtnText = new List<string>()
        { 
            "< Back To Home Page", "Top 21 Tips and Tricks You Must Know", "Best Ways to Level Up Fast", "10 Important Tips and Tricks", 
            "Tips from a Level 25 Trainer"
        };
    List<string> m_tipsAndTricksUrl = new List<string>()
        { 
            "HOME", "http://www.imore.com/Pokemon-go-tips-tricks-cheats", "http://www.pokemongodb.net/2016/04/5-best-ways-to-level-up-fast.html", "http://www.pokemongodb.net/2016/07/10-important-tips-tricks.html", 
            "http://www.pokemongodb.net/2016/07/tips-from-level-25-trainer.html"
        };
            

	void SetPanelActive(ScreenState state)
	{
		foreach (GameObject panel in m_uiPanels)
		{
			panel.SetActive(false);
		}

		m_uiPanels[(int) state].SetActive(true);

//		switch (state)
//		{
//			case ScreenState.UI_MAIN:
//				m_uiPanels[0].SetActive(true);
//			break;
//
//		case ScreenState.BASIC_INFO:
//				m_uiPanels[1].SetActive(true);
//			break;
//
//		case ScreenState.BEGINNER_TIPS:
//				m_uiPanels[2].SetActive(true);
//			break;
//
//		case ScreenState.GLOSSARY:
//				m_uiPanels[4].SetActive(true);
//			break;
//		}
	}

	void Awake()
	{
		m_currentState = ScreenState.UI_MAIN;
		SetPanelActive(ScreenState.UI_MAIN);

        PopulateButtonText(m_basicPanelButtons, m_basicBtnText);
        PopulateButtonText(m_beginnerTipsPanelButtons, m_beginnerBtnText);
		PopulateButtonText(m_pokedexPanelButtons, m_pokeDexPanelBtnText);
        PopulateButtonText(m_glossaryPanelButtons, m_glossaryBtnText);
        PopulateButtonText(m_batterySavingPanelButtons, m_batterySavingBtnText);
        PopulateButtonText(m_tipsAndTricksPanelButtons, m_tipsAndTricksBtnText);
	}

	void PopulateButtonText(List<GameObject> panelButtons, List<string> panelButtonText)
	{
		for(int i=0; i<panelButtons.Count; i++)
		{
			Text btnText = panelButtons[i].GetComponentInChildren<Text> ();
			if (btnText != null) 
			{
				btnText.text = panelButtonText[i];
			}
		}
	}

	public void ChangePanel(int screenState)
	{
		if (m_uiPanels.Count < screenState)
		{
			Debug.LogError("Invalid screen state: " + screenState + " out of bounds!");
			return;
		}
			
		m_currentState = (ScreenState) screenState;
		SetPanelActive((ScreenState)screenState);

		Debug.Log("State Now: " + m_currentState);
	}

	public void OnClick(int id)
	{


		// home URL
		if (id == 0)
		{
			ChangePanel((int)ScreenState.UI_MAIN);
		}
		else
		{

			Debug.Log("Current state is : " + m_currentState);
			string clickUrl = "";
			switch (m_currentState)
			{
                case ScreenState.BASIC_INFO:
                    clickUrl = m_basicUrl[id];
                    break;


                case ScreenState.BEGINNER_TIPS:
                    clickUrl = m_beginnerUrl[id];
                    break;

				case ScreenState.POKEDEX:
					clickUrl = m_pokedexPanelUrl[id];
					break;

                case ScreenState.BATTERY_SAVING:
                    clickUrl = m_batterySavingUrl[id];
                    break;

				case ScreenState.GLOSSARY:
                    clickUrl = m_glossaryUrl[id];
					break;

                case ScreenState.TIPS_AND_TRICKS:
                    clickUrl = m_tipsAndTricksUrl[id];
                    break;
			}

			Debug.Log("Click URL is : " + clickUrl);
			Application.OpenURL(clickUrl);
		}
	}
}
