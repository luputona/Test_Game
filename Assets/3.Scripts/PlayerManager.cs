using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private int playerMaxStamina;
    private int currentStamina;
    private int playerTempLevel;
    private int playerLevel;
    private int useStamina;

    private float maxExp;
    private float currentExp;

    public Slider staminaSlider;
    public Slider expSlider;

    public Text staminaText;
    public Text expText;
    public Text levelText;



	// Use this for initialization
	void Start () {



        playerLevel = 1;
        useStamina = 5;
        playerTempLevel = playerLevel;
        playerMaxStamina = 30;
        currentStamina = playerMaxStamina;
        staminaSlider.value = currentStamina;
        expSlider.value = 0;

        maxExp = 100;
        currentExp = 0;
        

       // staminaSlider = GetComponent<Slider>();

	}
	
	// Update is called once per frame
	void Update () {
       // ExpTable();

        Exp();
        PlayerStates();
	}

    void PlayerStates()
    {
        staminaSlider.maxValue = (float)playerMaxStamina;
        staminaSlider.value = (float)currentStamina;


        expText.text = string.Format("{0}/{1}", (int)currentExp, (int)maxExp);
        staminaText.text = currentStamina + "/" + playerMaxStamina;
        
        levelText.text = "" + playerLevel;
    }

    void Exp()
    {
        if (Input.GetKey(KeyCode.A))
        {            
            currentExp += 20;
            expSlider.value = currentExp;
            
            Debug.Log("currentExp : " + currentExp);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            
            staminaSlider.value = currentStamina;

            if (currentStamina >= useStamina)
            {
                useStamina = 5;
                currentStamina -= useStamina;
                return;
            }                
            else if (currentStamina < useStamina)
            {
                useStamina = 0;
            }
            
            
        }

        if (currentExp >= maxExp)
        {
            playerTempLevel = playerLevel;
            ++playerLevel;

            currentExp = 0;
            Debug.Log("maxExpcurrentExp : " + currentExp);
            if (playerLevel <= 10)
            {
                maxExp = (100 * playerLevel - maxExp * 60 / 100) + maxExp;
            }
            else if (playerLevel > 10 && playerLevel <= 40)
            {
                maxExp = (115 * playerLevel - maxExp * 45 / 100) + maxExp;
            }
            else if (playerLevel > 40 && playerLevel <= 100)
            {
                maxExp = (138 * playerLevel - maxExp * 40 / 100) + maxExp;
            }
        }
        if (playerLevel > playerTempLevel)
        {
            playerMaxStamina += 2;
            staminaSlider.value = playerMaxStamina;
            currentStamina = playerMaxStamina;

            expSlider.maxValue = maxExp;
            expSlider.value = 0;

            ++playerTempLevel;
        }

        Debug.Log("playerLevel : " + playerLevel);
    }


    void ExpTable()
    {
        if (playerLevel <= 10)
        {
            for (; playerLevel <= 10; playerLevel++)
            {
                maxExp = (100 * playerLevel - maxExp * 60 / 100) + maxExp;
                Debug.Log(playerLevel + " : " + (int)maxExp);         
            }
        }
        if (playerLevel > 10 && playerLevel <= 40)
        {
            for (; playerLevel <= 40; playerLevel++)
            {
                maxExp = (115 * playerLevel - maxExp * 45 / 100) + maxExp;
                Debug.Log(playerLevel + " : " + (int)maxExp);   

            }
        }
        if (playerLevel > 40 && playerLevel <= 100)
        {
            for (; playerLevel <= 100; playerLevel++)
            {
                maxExp = (138 * playerLevel - maxExp * 40 / 100) + maxExp;
                Debug.Log(playerLevel + " : " + (int)maxExp);
            }
        }
    }
}

public class PlayerState : Singleton_OBJ<PlayerState>
{
    public int playerMaxStamina { get; set; }
    public int currentStamina { get; set; }
    public int playerTempLevel { get; set; }
    public int playerLevel { get; set; }
    public int useStamina { get; set; }

    public float maxExp { get; set; }
    public float currentExp { get; set; }


    

    public void SetPlayerState(int _level, int _maxStamina, float _maxExp)
    {
        this.playerLevel = _level;
        this.playerTempLevel = playerLevel;
        this.playerMaxStamina = _maxStamina;
        this.currentStamina = playerMaxStamina;

        this.maxExp = _maxExp;
        this.currentExp = 0;

    }



    public PlayerState()
    {
    }

}