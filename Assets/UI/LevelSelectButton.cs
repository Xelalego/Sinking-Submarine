using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text LevelNumber;
    [SerializeField]
    private Image[] Stars;

    public LevelConfig Config;

    public Sprite FullStar;
    public Sprite EmptyStar;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        LevelNumber.text = Config.LevelNumber.ToString();
        // Stars are currently randomly generated, as the save system is not implemented yet
        int dummyStars = Random.Range(0, 4);
        for (int i = 0; i < 3; i++)
        {
            // Check if this level has i or more stars
            if (i + 1 <= dummyStars)
            {
                Stars[i].sprite = FullStar;
            }
            else
            {
                Stars[i].sprite = EmptyStar;
            }
        }
    }

    public void Select()
    {
        Game.CurrentLevel = Config;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
