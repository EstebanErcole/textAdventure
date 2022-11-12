using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GridLayoutAutoExpand : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public CanvasScaler canvasScaler;
    public GameObject TextObject;
    public GameObject MessagesWrapper;

    Vector3 cellSize;
    void Start()
    {
        RecalculateGridLayout();
        this.cellSize = gridLayout.cellSize;
    }

    void RecalculateGridLayout()
    {
        if (gridLayout != null)
        {

                        
            
            //Vector2 resolutionRender = new Vector2(Display.main.renderingHeight, Display.main.renderingWidth);
            //float ratioDevice = resolutionRender.x / resolutionRender.y;
            //float ratioHD = 1080f / 1920f;
            //float childWidth;
            //float cosmologicConstant = 11f / 0.1875f; //I have no idea why do I need to multiply by this number if ratioDevice > ratioHD.
            //if (ratioDevice <= ratioHD)
            //{
            //    childWidth = cellSize.x * (ratioDevice / ratioHD);
            //}
            //else
            //{
            //    childWidth = cellSize.x * (ratioDevice / ratioHD) - (ratioDevice - ratioHD) * cosmologicConstant;
            //}

            //float childHeight = childWidth;
            int ClientW = Display.main.renderingWidth;
            int bubbleWrapper = ClientW - 116 - 170;
            
            TMPro.TextMeshProUGUI _labelField = TextObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0];

            
            //TextObject.GetComponent<TMPro.TextMeshProUGUI>().ForceMeshUpdate();


            int numberOfRows = TextObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text.Length;
            TMPro.TextMeshProUGUI teto = TextObject.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0];
            Debug.Log(teto.GetComponent<RectTransform>().sizeDelta.y);
            int cellY = 40;

            if (numberOfRows > 35)
            {
                int remaining = (numberOfRows - 35);
                int roundUp = (int)Mathf.Ceil(remaining / 35);
                int incremental = roundUp * 70; // 50 altura + 20 de lineheight
                Debug.Log(remaining + " - " + roundUp + " - " + incremental);
                cellY += incremental;
            }

            cellSize.x = _labelField.preferredWidth < bubbleWrapper ? _labelField.preferredWidth : bubbleWrapper;
            cellSize.y = cellY;

            gridLayout.cellSize = cellSize;


        }
    }

    void UpdaGridHiehgt()
    {
        
    }
}
