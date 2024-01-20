using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private List<Image> scoreDisplay;
    [SerializeField] private Image livesDisplay;
    [SerializeField] private Image powerDisplay;
    [SerializeField] private Image shieldDisplay;

    [Header("Number Sprites")]
    [SerializeField] private List<Sprite> numbers;

    private void Awake()
    {
        Instance = this;
    }

    private Sprite GetNumberSprite(int num)
    {
        return numbers[num];
    }

    private List<int> DigitExtract(int num)
    {
        List<int> digits = new();

        while (num != 0)
        {
            digits.Add(num % 10);

            num /= 10;
        }

        return digits;
    }

    public void UpdateScoreUI(int score)
    {
        List<int> digits = DigitExtract(score);

        for (int i  = 0; i < digits.Count; i++)
        {
            scoreDisplay[i].sprite = GetNumberSprite(digits[i]);
        }
    }

    public void UpdateLivesUI(int lives)
    {
        livesDisplay.sprite = GetNumberSprite(lives);
    }

    public void UpdatePowerUI(int power)
    {
        powerDisplay.sprite = GetNumberSprite(power);
    }

    public void UpdateShieldUI(int shield)
    {
        shieldDisplay.sprite = GetNumberSprite(shield);
    }
}
