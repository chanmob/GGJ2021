using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectEvent : MonoBehaviour
{
    /// <summary>
    /// 배가 들어온 숫자마다 각각 카운트 들어감.
    /// 가장 카운트가 높은 배의 대사를 출력.
    /// 호감도는 2 증가
    /// 나쁜 선택지 2 감소, 허나 기본이 0일 경우 0 그대로 유지 
    /// </summary>
    string[] firshipfirDay = new string[5];  // 첫번째 배 첫 날 대사
    string[] firshipSecDay = new string[5]; // 첫번째 배 둘째 날 대사 
    string[] firshipThrDay = new string[5]; // 첫번째 배 셋째 날 대사

    string day = "";
    int point = 50;

    public Image characterImage, sub_characterImage, sub_characterImage_Sel;
    
    public Text characterName, characterName_Sel, charTxt, pointTxt, badOrGood, badBtnTxt, goodBtnTxt;
    
    public Slider pointSlider;

    public Button badBtn, goodBtn, UIBtn;

    public GameObject TextPanel, BtnPanel;

    public Sprite[] characterType;

    void Start()
    {
        TextPanel.SetActive(true);
        BtnPanel.SetActive(false);

        firshipfirDay[0] = "안전하게 길을 안내해주셔서 감사합니다.";
        firshipfirDay[1] = "무사히 들어가셔서 다행이네요.";
        firshipfirDay[2] = "내가 할일 한거니 신경쓰지 마쇼.";
        firshipfirDay[3] = "앞으로도 잘 부탁드립니다. 등대지기님.";
        firshipfirDay[4] = "(칫 건방지구만) 알겠소.";

        firshipSecDay[0] = "날씨가 선선하니 딱 책읽기 좋은 날씨네요.";
        firshipSecDay[1] = "그러게요. 마음이 차분해지는 날입니다.";
        firshipSecDay[2] = "책읽을 시간이 어딨습니까 잠 잘 시간도 없는데.";
        firshipSecDay[3] = "여기 제가 재밌게 읽었던 책입니다. 한번 봐보세요.";
        firshipSecDay[4] = "가보도록 하겠소.";

        firshipThrDay[0] = "쉬는날에 약속 있으십니까?";
        firshipThrDay[1] = "아뇨, 쉬는날에 같이 본 책에 대해 이야기좀 할까요?";
        firshipThrDay[2] = "너무 피곤해서 집에서 잠이나 자야할것같소.";
        firshipThrDay[3] = "그러면 토요일날 봐요~";
        firshipThrDay[4] = "집에서 무식하게 잠이나 자쇼.";

        day = "Fir";    // 임의대로 day를 선언해둠.

        StartCoroutine("EventStart");
    }

    void Update()
    {
        pointSlider.value = point;
        pointTxt.text = point.ToString() + "%"; 
    }
   
    public void onClickBadBtn()
    {
        if(point < 2)
        {
            point = 0;
        }
        else
        {
            point = point - 2;
        }


        if(day == "Fir")
        {
            charTxt.text = "";
            badOrGood.text = firshipfirDay[4];
            characterImage.sprite = characterType[3];
        }
        else if(day == "Sec")
        {
            charTxt.text = "";
            badOrGood.text = firshipSecDay[4];
            characterImage.sprite = characterType[3];
        }
        else if(day == "Thr")
        {
            charTxt.text = "";
            badOrGood.text = firshipThrDay[4];
            characterImage.sprite = characterType[3];
        }

        TextPanel.SetActive(true);
        BtnPanel.SetActive(false);
    }

    public void onClickGoodBtn()
    {
        if(point + 35 > 100)
        {
            point = 100;
        }
        else
        {
            point = point + 35;
        }

        if (day == "Fir")
        {
            charTxt.text = "";
            badOrGood.text = firshipfirDay[3];
            characterImage.sprite = characterType[4];
        }
        else if (day == "Sec")
        {
            charTxt.text = "";
            badOrGood.text = firshipSecDay[3];
            characterImage.sprite = characterType[4];
        }
        else if (day == "Thr")
        {
            charTxt.text = "";
            badOrGood.text = firshipThrDay[3];
            characterImage.sprite = characterType[4];
        }

        TextPanel.SetActive(true);
        BtnPanel.SetActive(false);
    }

    IEnumerator EventStart()
    {
        while(true)
        {
            if(day == "Fir")
            {
                if(point < 40)
                {
                    characterImage.sprite = characterType[1];
                }   
                else if(point <= 40 || point > 70)
                {
                    characterImage.sprite = characterType[0];
                }
                else if(point <= 70 || point >= 100)
                {
                    characterImage.sprite = characterType[2];
                }    
                sub_characterImage.sprite = characterType[5];
                sub_characterImage_Sel.sprite = characterType[5];
                charTxt.text = firshipfirDay[0];
                characterName.text = "무역함 선장";
                characterName_Sel.text = "무역함 선장";
                goodBtnTxt.text = firshipfirDay[1];
                badBtnTxt.text = firshipfirDay[2];
                badOrGood.text = "";

                if (Input.GetMouseButtonDown(0))
                {
                    TextPanel.SetActive(false);
                    BtnPanel.SetActive(true);

                    break;
                }
            }
            else if(day == "Sec")
            {
                if (point < 40)
                {
                    characterImage.sprite = characterType[1];
                }
                else if (point <= 40 || point > 70)
                {
                    characterImage.sprite = characterType[0];
                }
                else if (point <= 70 || point >= 100)
                {
                    characterImage.sprite = characterType[2];
                }
                sub_characterImage.sprite = characterType[5];
                sub_characterImage_Sel.sprite = characterType[5];
                charTxt.text = firshipSecDay[0];
                characterName.text = "무역함 선장";
                characterName_Sel.text = "무역함 선장";
                goodBtnTxt.text = firshipSecDay[1];
                badBtnTxt.text = firshipSecDay[2];
                badOrGood.text = "";

                if (Input.GetMouseButtonDown(0))
                {
                    TextPanel.SetActive(false);
                    BtnPanel.SetActive(true);

                    break;
                }
            }
            else if(day == "Thr")
            {
                if (point < 40)
                {
                    characterImage.sprite = characterType[1];
                }
                else if (point <= 40 || point > 70)
                {
                    characterImage.sprite = characterType[0];
                }
                else if (point <= 70 || point >= 100)
                {
                    characterImage.sprite = characterType[2];
                }
                sub_characterImage.sprite = characterType[5];
                sub_characterImage_Sel.sprite = characterType[5];
                charTxt.text = firshipThrDay[0];
                characterName.text = "무역함 선장";
                characterName_Sel.text = "무역함 선장";
                goodBtnTxt.text = firshipThrDay[1];
                badBtnTxt.text = firshipThrDay[2];
                badOrGood.text = "";

                if (Input.GetMouseButtonDown(0))
                {
                    TextPanel.SetActive(false);
                    BtnPanel.SetActive(true);

                    break;
                }
            }

            yield return null;
        }
    }
}
