using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button button;
    public EventManager eventManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was pressed");
        eventManager.startGameEvent?.Invoke(difficulty);
    }
}
