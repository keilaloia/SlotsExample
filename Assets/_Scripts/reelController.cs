using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class reelController : MonoBehaviour
{


    private reelModel _rModel;


    public Image[] Reel = new Image[5];

    [Space(10)]//pretty up the inspector

    public Sprite Hearts;
    public Sprite Diamond;
    public Sprite Clubs;
    public Sprite Spades;

    public event Action FoundMatch = delegate { };
    
    private void Start()
    {
        _rModel = GetComponent<reelModel>();

        clickEvent.instance.clicked += onClick;
    }

    private void onClick()//run our slots
    {
        runSpin(15f, 1f);
    }
    public void runSpin(float runTime, float swapTime)
    {
        StartCoroutine(timeFirst(runTime, swapTime));
    }

    private Image ImagePicker(string Image, Image Curr)
    {
        switch (Image)
        {
            case "HEARTS":
                Curr.sprite = Hearts;
                break;
            case "CLUBS":
                Curr.sprite = Clubs;
                break;
            case "DIAMOND":
                Curr.sprite = Diamond;
                break;
            case "SPADES":
                Curr.sprite = Spades;
                break;
            default:
                Debug.LogError("Image does not exist");
                break;
        }
        return Curr;
    }

    private int imageEquation(int _num, int addition, int arrayLength)//cool equation for image swapping
    {
        return _num + addition <= arrayLength ? _num + addition : arrayLength - _num - addition < 0 ? ((arrayLength - _num - addition) * -1) - 1 : 0;
    }

    public IEnumerator timeFirst(float Duration, float swapTime)//swap through images
    {

        int num = 0;
        float currentTime = 0;
        int length = _rModel.reelPool.Length - 1;

        ImagePicker(_rModel.reelPool[0], Reel[0]);

        while (currentTime < Duration)
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime < swapTime)
            {
                num = num + 1;
                num = num > length ? 0 : num;// if num is == length go back to 0

                ImagePicker(_rModel.reelPool[imageEquation(num, 0, length)], Reel[0]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 1, length)], Reel[1]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 2, length)], Reel[2]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 3, length)], Reel[3]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 4, length)], Reel[4]);


            }

            else if (currentTime > swapTime)
            {
                num = num + 1;
                num = num > _rModel.reelPool.Length - 1 ? 0 : num;// if num is == length go back to 0

                ImagePicker(_rModel.reelPool[imageEquation(num, 0, length)], Reel[0]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 1, length)], Reel[1]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 2, length)], Reel[2]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 3, length)], Reel[3]);
                ImagePicker(_rModel.reelPool[imageEquation(num, 4, length)], Reel[4]);

                //tell the watching scripts that we have hit our target image
                if(imageEquation(num,2,length) == spinModel.instance.ReelIndex[_rModel.slot])
                {

                    if (FoundMatch != null)
                    {
                        FoundMatch();
                    }
                    yield break;
                }

            }
            yield return null;

        }



    }
}
