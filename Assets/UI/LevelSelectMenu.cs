using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    public List<LevelConfig> LevelConfigs = new();
    public GameObject LevelSelectButtonPrefab;

    [SerializeField]
    private float ButtonSpawnRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelUI());
    }

    IEnumerator LoadLevelUI()
    {
        for (int i = 1; i <= LevelConfigs.Count; i++)
        {
            LevelSelectButton newButton = Instantiate(LevelSelectButtonPrefab, transform).GetComponent<LevelSelectButton>();
            newButton.Config.LevelNumber = i;
            newButton.UpdateVisuals();
            yield return new WaitForSeconds(ButtonSpawnRate);
        }
    }

    public void NewGame()
    {
        Game.CurrentLevel = LevelConfigs[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
