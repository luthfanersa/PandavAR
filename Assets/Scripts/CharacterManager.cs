using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterManager : MonoBehaviour
{

    public CharacterDatabase characterDB;
  
    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }

  public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void PlayOption()
    {
      

        if (selectedOption == 0)
        {
            //YUDHISTIRA GAME
            LevelManager.Instance.LoadScene("Game Yudhistira");
        }else if(selectedOption==1)
        {
            //BIMA GAME
            LevelManager.Instance.LoadScene("Game Bima");
        }
        else if (selectedOption == 2)
        {
            //ARJUNA GAME
            LevelManager.Instance.LoadScene("Game Arjuna");
        }
        else if (selectedOption == 3)
        {
            //NAKULA GAME
            LevelManager.Instance.LoadScene("Game Nakula Sadewa");
        }
        else if (selectedOption == 4)
        {
            //SADEWA GAME
            LevelManager.Instance.LoadScene("Game Nakula Sadewa");
        }


    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
