using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionsScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

// string: name, bool: state
    public Dictionary<string, bool> tasks = new Dictionary<string, bool>();

      public GameObject part;
      public Transform actionsParent;
      public TextMeshProUGUI checkText;
    private VerticalLayoutGroup layoutGroup;
    void Start()
    {
         checkText = GameObject.Find("CheckText").GetComponent<TextMeshProUGUI>();
        layoutGroup = actionsParent.GetComponent<VerticalLayoutGroup>();

    }

    public void AddTask(string name, bool state) {
        tasks.Add(name, state);
        GameObject go = Instantiate(part, actionsParent);
        go.transform.localScale = Vector3.one;

        TextMeshProUGUI label = go.GetComponentInChildren<TextMeshProUGUI>();
        Button button = go.GetComponentInChildren<Button>();
        
        button.GetComponent<Image>().color = state ? new Color(0,1,0) : new Color(1,0,0);
        label.text = name;
        layoutGroup.enabled = false;  // Temporarily disable the layout group to apply custom adjustments
        layoutGroup.enabled = true;   // Re-enable to adjust layout after the new element is added

        UpdateProgress();
    }
    void UpdateProgress() {
int doneTasks = 0;
    foreach (var task in tasks)
    {
        if (task.Value) doneTasks++;
    } 
    
    checkText.text = $"{doneTasks}/{tasks.Count}";
    }
    public void RemoveTask(string name) {
        tasks.Remove(name);
          foreach (Transform child in actionsParent) {
            if(child.GetComponentInChildren<TextMeshProUGUI>().text == name) Destroy(child.gameObject);  
    }
    }
    public void FinishTask(string name) {
        if(!tasks.ContainsKey(name)) return;
        tasks[name] = true;
    }
    public void FlushTasks() {
        tasks.Clear();
          foreach (Transform child in actionsParent) {
        Destroy(child.gameObject);  
    }
    UpdateProgress();
    }
 
}
