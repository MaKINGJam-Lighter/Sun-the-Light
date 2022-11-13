using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationManager : MonoBehaviour
{
    Dictionary<int, string[]> storyData;

    void Start()
    {
        storyData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        storyData.Add(1, new string[] {"나, 태양신 헬리오스.",
        "신의 일은 대개 눈코뜰 새 없이 바쁜 것들이지만 그중에서도 태양을 주관하는 일은 올림포스의 그 어떤 신들보다도 부지런해야 하는 일이다.",
        "우선 새벽 닭이 울기 전에 하루를 시작해야 한다. 동쪽의 궁전에서 솟아올라 서쪽 헤스페리데스의 땅까지 가려면 결코 늦장을 부려서는 안 된다. 서쪽 땅에 도착하고 나면, 숨 돌릴 틈도 없이 다시 동쪽 궁전으로 돌아와야 하니 이보다 더 바쁠 수는 없다.",
        "이 세상을 골고루 환하게 비추는 일같은, 아주 중요한 책임을 맡다보면...\n가끔... ......\n이렇게 졸음이...... ....\n.....쏟아.........지기도 ....................",
        " ...!!!",
        "뭐야!!",
        "태양이 사라졌다니! 어떻게 된 일이지?\n내가 태양을 놓친 적은 지금까지 단 한 번도 없었는데...!",
        "이렇게 두고만 볼 수는 없다.\n이대로라면 황금 마차의 명성을 잃게 될 것이 분명하다.",
        ""});
    }

    public string GetStory(int id, int storyIndex)
    {
        if (storyIndex == storyData[id].Length)
            return null;
        else
            return storyData[id][storyIndex];
    }
}
