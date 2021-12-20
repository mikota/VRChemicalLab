using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TPScript : MonoBehaviour
{
    public Button botun;
    public Transform Teleport1;

    private void Start()
    {
        //botun = GetComponent<Button>();
        botun.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if (botun.IsActive())
        {
            transform.position = Teleport1.position;
        }
    }

    

}