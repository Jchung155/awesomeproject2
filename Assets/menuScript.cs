using UnityEngine;

public class menuScript : MonoBehaviour
{
    public static bool paused = false;
    public GameManager gameManager;
    public GameObject gameManagerObject;
    public GameObject playerObject;
    public FirstPersonController player;
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        player = playerObject.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.upgradeTime)
        {
            Pause();
        }
    }

    public void Resume() {

        menu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        gameManager.upgradeTime = false;
    }

    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UpgradeHealth()
    {
        player.health++;
        player.maximumHealth++;

        Resume();
    }

    public void UpgradeSpeed()
    {
        player.WalkSpeed += 1.5f;
        Resume();
    }

    public void UpgradeDamage()
    {
        player.damage += 0.25f;
        Resume();
    }

    public void UpgradeJump()
    {
        player.JumpPower += 0.5f;
        Resume();
    }

    public void UpgradeKnockback()
    {
        player.knockbackUpgrade++;
        Resume();
    }

    public void upgradeFireRate()
    {
        player.fireTime -= 0.025f;
        Resume();
    }

    public void upgradeBulletSpeed()
    {
        player.bulletSpeedUpgrade += 2;
        Resume();
    }
}
