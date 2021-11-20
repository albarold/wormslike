using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParents;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;
    [SerializeField] [Range(0.01f,0.03f)] float dotMinScale;
    [SerializeField] [Range(0.03f,1f)] float dotMaxScale;

    Transform[] dotsList;

    Vector2 pos;
    float timeStamp;


    private void Start()
    {
        Hide();

        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;
        float scale = dotMaxScale;
        float scaleFactor = scale/dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParents.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale>dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 SkelPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            pos.x = (SkelPos.x + forceApplied.x * timeStamp);
            pos.y = (SkelPos.y + forceApplied.y * timeStamp)-(Physics2D.gravity.magnitude*timeStamp*timeStamp)/2f;

            dotsList[i].position = pos;
            timeStamp += dotSpacing;
        }
    }
    public void Show()
    {
        dotsParents.SetActive(true);
    }    
    public void Hide()
    {
        dotsParents.SetActive(false);
    }
}
