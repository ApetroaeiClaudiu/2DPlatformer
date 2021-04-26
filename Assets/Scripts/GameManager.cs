using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Sophie;
    public GameObject Claude;
    public int SophieHealth;
    public int ClaudeHealth;
    public GameObject SophieWins;
    public GameObject ClaudeWins;
    public GameObject[] SophieDiamonds;
    public GameObject[] ClaudeDiamonds;
    public string MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SophieHealth <= 0 ){
            Sophie.SetActive(false);
            ClaudeWins.SetActive(true);
        }
        if(ClaudeHealth <= 0 ){
            Claude.SetActive(false);
            SophieWins.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(MainMenu);
        }
    }

    public void DamageSophie(){
        SophieHealth -= 1;
        for(int i=0;i<SophieDiamonds.Length;i++){
            if(SophieHealth > i ){
                SophieDiamonds[i].SetActive(true);
            }
            else{
                SophieDiamonds[i].SetActive(false);
            }
        }
    }
    public void DamageClaude(){
        ClaudeHealth -= 1;  
        for(int i=0;i<ClaudeDiamonds.Length;i++){
            if(ClaudeHealth > i ){
                ClaudeDiamonds[i].SetActive(true);
            }
            else{
                ClaudeDiamonds[i].SetActive(false);
            }
        }
    }
}
