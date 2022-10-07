using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result_Scene_Text : MonoBehaviour
{
    public TextMeshProUGUI player, AI, Result_Message;
    // Start is called before the first frame update
    void Start()
    {        
        int[] scores = new int[2]; 
        scores = Game_Control.get_result_score(); // scores == array of [plauer score, AI score]

        // substitute scores for each Text-Mesh-Pro objects
        player.text = "My Score\n" + scores[0];
        AI.text = "AI Score\n" + scores[1];

        // Result message according to victory or defeat
        if( scores[0] > scores[1] ) Result_Message.text = "You Win!";
        else if ( scores[0] == scores[1] ) Result_Message.text = "Drow";
        else Result_Message.text = "You Lose...";
        
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
