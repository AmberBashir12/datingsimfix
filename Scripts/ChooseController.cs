using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection.Emit;
using System.Drawing;
using UnityEditor.SearchService;

public class ChooseController : MonoBehaviour
{

    public ChooseLabelController chooseLabelController;
    public GameController gameController;
    private RectTransform rectTransform;
    public Animator animator;
    private float labelHeight = -1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupChoose(ChooseScene scene)
    {
        DestroyLabels();
        animator.SetTrigger("Show");
        for (int index = 0; index < scene.labels.Count; index++) 
        { 
            ChooseLabelController newLabel = Instantiate(chooseLabelController.gameObject, transform).GetComponent<ChooseLabelController>();

            if(labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[index], this, CalculateLabelPosition(index, scene.labels.Count));
        }


        Vector2 size = rectTransform.sizeDelta;
        size.y = (scene.labels.Count + 1) * labelHeight;
        rectTransform.sizeDelta = size;
    }

    public void PerformChoose(StoryScene scene)
    {
        gameController.PlayScene(scene);
        animator.SetTrigger("Hide");
    }

    private float CalculateLabelPosition(int labelCount, int labelIndex)
    {
        if (labelCount % 2 == 0) 
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex - 1) + labelHeight / 2;
            }
            else
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2) + labelHeight / 2);
            }
        }
        else
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex);
            }
            else if (labelIndex > labelCount / 2)
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2));
            }
            else
            {
                return 0;
            }
        }
    }

    private void DestroyLabels()
    {
        foreach (Transform childTransform in transform) 
        
        {
            Destroy(childTransform.gameObject);

        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
