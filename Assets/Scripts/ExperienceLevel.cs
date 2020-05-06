using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextHitGenerator))]
public class ExperienceLevel : MonoBehaviour
{
    public Image ExperienceBar;

    public AttributeButton[] attributeButtons;
    public int CurrentExp { get; private set; }
    public float NextLevelPercentage { get; private set; }
    public int CurrentLevel { get; private set; }
    public int AttributePoints { get; private set; }
    public int NextLevelExperience { get; private set; }


    private PlayerController _player;
    private Health _health;
    private TextHitGenerator textGenerator;
    private Range rangeTextLevelUp = new Range()
    {
        MinValue = 0,
        MaxValue = 0
    };


    // Start is called before the first frame update
    void Start()
    {
        CurrentLevel = 1;
        CurrentExp = 0;
        NextLevelPercentage = 0;
        NextLevelExperience = levelNeededExperience(CurrentLevel);
        textGenerator = GetComponent<TextHitGenerator>();
        _player = GetComponent<PlayerController>();
        _health = GetComponent<Health>();

        
        AttributePanel.Instance.UpdateLabels(_player.PlayerStats, _health, this);
        UpdateExpBar();
        CallSwitchButtons();
    }

    public void AddExperience(int gainedExp)
    {
        int remainingExp = gainedExp;

        do
        {
            CurrentExp += remainingExp;
            remainingExp = CurrentExp - NextLevelExperience;
            if (CurrentExp >= NextLevelExperience) //LevelUp!!
            {
                levelUp();
            }
        } while (remainingExp > 0);

        NextLevelPercentage = (float)CurrentExp / NextLevelExperience;
        UpdateExpBar();

        AttributePanel.Instance.UpdateLabels(_player.PlayerStats, _health, this);
    }

    private int levelNeededExperience(int level)
    {
        int result = 0;

        result = (int)Mathf.Log(level, 3) * 50 + 10;

        return result;
    }

    private int accumulatedExperience(int level)
    {
        int result = 0;

        for(int i = 1; i < level; i++)
        {
            result += levelNeededExperience(i);
        }
        
        return result;
    }

    private void levelUp()
    {
        CurrentLevel++;
        CurrentExp = 0;
        AttributePoints += 1;
        textGenerator.CreateTextHit(textGenerator.factoryTextHit, "Level UP!", transform, 0.4f, Color.cyan, rangeTextLevelUp, rangeTextLevelUp, 2f);
        NextLevelExperience = levelNeededExperience(CurrentLevel);
        CallSwitchButtons();

        AttributePanel.Instance.UpdateLabels(_player.PlayerStats, _health, this);
    }

    public void UpdateExpBar()
    {
        ExperienceBar.fillAmount = NextLevelPercentage;
    }

    public void ConsumeAttributePoints(int amount)
    {
        AttributePoints -= amount;
        CallSwitchButtons();

        AttributePanel.Instance.UpdateLabels(_player.PlayerStats, _health, this);
    }

    private void CallSwitchButtons()
    {
        if(attributeButtons != null)
        {
            foreach (AttributeButton btn in attributeButtons)
            {
                btn.SwitchButton(AttributePoints);
            }
        }
    }
}
