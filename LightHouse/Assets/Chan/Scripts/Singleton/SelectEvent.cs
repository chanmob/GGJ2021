using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectEvent : MonoBehaviour
{
    string[] firshipfirDay = new string[5];  // 첫번째 배 첫 날 대사
    string[] firshipSecDay = new string[5]; // 첫번째 배 둘째 날 대사 
    string[] firshipThrDay = new string[5]; // 첫번째 배 셋째 날 대사
    string[] endIngArr = new string[9];

    int point = 50;

    public static int intDay;

    public Image characterImage, sub_characterImage, sub_characterImage_Sel, endIngIma;

    public Text characterName, characterName_Sel, charTxt, pointTxt, badOrGood, badBtnTxt, goodBtnTxt, endIngTxt1
        , endIngTxt2, endIngTxt3, endIngTxt4, endIngTxt5, endIngTxt6, endIngTxt7;

    public Slider pointSlider;

    public Button badBtn, goodBtn, UIBtn;

    public GameObject TextPanel, BtnPanel, EventObj, endIngObj,endInggImaObj;

    public Sprite[] characterType;

    void Start()
    {
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

        endIngArr[0] = "오랜만에 침대가 아니라 외출이라니 조금 힘들었지만";
        endIngArr[1] = "따뜻한 차와 책 그리고 마음맞는 친구 편안한 휴일이었다.";
        endIngArr[2] = "Happy Ending";
        endIngArr[3] = "기획자 : 서동욱";
        endIngArr[4] = "프로그래머 : 김찬영";
        endIngArr[5] = "프로그래머 : 전완익";
        endIngArr[6] = "아트 : 이창현";
        endIngArr[7] = "아트 : 정상준";
        endIngArr[8] = "Thank You";


        EventObj.SetActive(false);
        endIngObj.SetActive(false);
        intDay = 0;

        StartCoroutine("EventStart");
    }

    void Update()
    {
        pointSlider.value = point;
        pointTxt.text = point.ToString() + "%";
    }

    public void onClickBadBtn()
    {
        if (point < 2)
        {
            point = 0;
        }
        else
        {
            point = point - 2;
        }

        if (intDay == 0)
        {
            charTxt.text = "";
            badOrGood.text = firshipfirDay[4];
            characterImage.sprite = characterType[3];
            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }
        else if (intDay == 1)
        {
            charTxt.text = "";
            badOrGood.text = firshipSecDay[4];
            characterImage.sprite = characterType[3];
            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }
        else if (intDay == 2)
        {
            charTxt.text = "";
            badOrGood.text = firshipThrDay[4];
            characterImage.sprite = characterType[3];

            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }

        StartCoroutine("EndIng");
    }

    public void onClickGoodBtn()
    {
        if (point + 35 > 100)
        {
            point = 100;
        }
        else
        {
            point = point + 35;
        }

        if (intDay == 0)
        {
            charTxt.text = "";
            badOrGood.text = firshipfirDay[3];
            characterImage.sprite = characterType[4];

            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }
        else if (intDay == 1)
        {
            charTxt.text = "";
            badOrGood.text = firshipSecDay[3];
            characterImage.sprite = characterType[4];

            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }
        else if (intDay == 2)
        {
            charTxt.text = "";
            badOrGood.text = firshipThrDay[3];
            characterImage.sprite = characterType[4];

            TextPanel.SetActive(true);
            BtnPanel.SetActive(false);
        }

        StartCoroutine("EndIng");
    }
    
    IEnumerator EndIng()
    {
        yield return new WaitForSeconds(4f);

        endIngObj.SetActive(true);

        for (int i = 0; i < 9; i++)
        {
            if(i < 2)
            {
                endIngIma.sprite = characterType[6];
                endIngTxt1.text = endIngArr[i];
                endIngTxt2.text = "";
                endIngTxt3.text = "";
                endIngTxt4.text = "";
                endIngTxt5.text = "";
                endIngTxt6.text = "";
                endIngTxt7.text = "";
                yield return new WaitForSeconds(4f);
            }
            else if(i == 2)
            {
                endInggImaObj.SetActive(false);
                endIngTxt1.text = "";
                endIngTxt2.text = endIngArr[i];
                endIngTxt3.text = "";
                endIngTxt4.text = "";
                endIngTxt5.text = "";
                endIngTxt6.text = "";
                endIngTxt7.text = "";
                yield return new WaitForSeconds(4f);
            }
            else if(i == 3 || i == 4 || i == 5 || i == 6)
            {
                endInggImaObj.SetActive(false);
                endIngTxt1.text = "";
                endIngTxt2.text = "";

                endIngTxt3.text = endIngArr[3];
                endIngTxt4.text = endIngArr[4];
                endIngTxt5.text = endIngArr[5];
                endIngTxt6.text = endIngArr[6];
                endIngTxt7.text = endIngArr[7];
                yield return new WaitForSeconds(1f);
            }
            else if(i == 7 || i == 8)
            {
                endInggImaObj.SetActive(false);
                endIngTxt1.text = "";
                endIngTxt2.text = endIngArr[8];
                endIngTxt3.text = "";
                endIngTxt4.text = "";
                endIngTxt5.text = "";
                endIngTxt6.text = "";
                endIngTxt7.text = "";
                yield return new WaitForSeconds(4f);
            }
        }
    }

    IEnumerator EventStart()
    {
        while (true)
        {
            if (intDay == 0)
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
                charTxt.text = firshipfirDay[0];
                characterName.text = "무역함 선장";
                characterName_Sel.text = "무역함 선장";
                goodBtnTxt.text = firshipfirDay[1];
                badBtnTxt.text = firshipfirDay[2];
                badOrGood.text = "";

                //TextPanel.SetActive(true);
                //BtnPanel.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                    TextPanel.SetActive(false);
                    BtnPanel.SetActive(true);

                    break;
                }
            }
            else if (intDay == 1)
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

                //TextPanel.SetActive(true);
                //BtnPanel.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                    TextPanel.SetActive(false);
                    BtnPanel.SetActive(true);

                    break;
                }
            }
            else if (intDay == 2)
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

                //TextPanel.SetActive(true);
                //BtnPanel.SetActive(false);

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