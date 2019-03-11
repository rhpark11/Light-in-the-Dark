using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDialogueManager : MonoBehaviour
{
    
    // Nurse = 0
    // Engineer = 1
    // Researcher = 2
    
    public DialogueQue dQ;

    public List<Dialog> nurse;
   
    
    public List<Dialog> engineer;
   

    public List<Dialog> researcher;
   

    private List<Dialog>[] characters = new List<Dialog>[3];
    private int character_index = 0;
    
    private int[] index_array = new int[3];
    
    public float delay_min = 10f;
    public float delay_max = 20f;
    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        characters[0] = engineer;
        characters[1] = nurse;
        characters[2] = researcher;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            
            if(characters[character_index].Count > index_array[character_index])
            {
                dQ.dialogQ.Enqueue(characters[character_index][index_array[character_index]]);
                index_array[character_index]++;
                delay = Random.Range(delay_min, delay_max);
            }
            
            character_index++;
            character_index = character_index % 3;
         
        }

    }
}
