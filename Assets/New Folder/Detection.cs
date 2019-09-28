using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 检测并对话
/// </summary>
public class Detection : MonoBehaviour {

    public List<AudioClip> audioClips=new List<AudioClip>();
    public AudioSource audioSource;
    public GameObject eye;
    public List<string> duiHua = new List<string>();
    /// <summary>
    /// true是显示基数行，fore 显示
    /// </summary>
    public bool iaXian=true;
    Text text;
    // Use this for initialization
    void Start () {
        text =GetComponentInChildren<Text>();
        text.transform.parent.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //距离检测
        if ((transform.position-eye.transform.position).magnitude<4)
        {
            if (!isPlay)
            {
                isPlay = true;
                Play();
                
            }
        }
        else
        {
            isPlay = false;
            isJianChe = false;
            audioSource.Pause();
            text.transform.parent.gameObject.SetActive(false);
        }


        //播放检测     
        if (isJianChe)
        {
            if (!audioSource.isPlaying)
            {
                //延迟播放
                Invoke("YanChiPlay", 2);
                isJianChe = false;
            }
        }
    }
    bool isPlay;
    bool isJianChe;
    int i;
    /// <summary>
    /// 播放对话
    /// </summary>
    public void Play()
    {
        i = 0;
        if (iaXian)
        {
           text.transform.parent.gameObject.SetActive(true);
           text.text = duiHua[i];
        }
        audioSource.clip = audioClips[i];
        audioSource.Play();
        isJianChe = true;
    }
    /// <summary>
    /// 延迟播放
    /// </summary>
    public void YanChiPlay()
    {
        i++;
        if (i < audioClips.Count)
        {
       
            if ((i+1)%2==0&& !iaXian)
        {
           text.transform.parent.gameObject.SetActive(true);
           text.text = duiHua[i];
        }
        else if((i + 1) % 2 != 0 && iaXian)
        {
           text.transform.parent.gameObject.SetActive(true);
           text.text = duiHua[i];
        }
        else
        {
           text.transform.parent.gameObject.SetActive(false);
        }
        if (i< audioClips.Count)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play();
            isJianChe = true;
        }
        }
    }
}
