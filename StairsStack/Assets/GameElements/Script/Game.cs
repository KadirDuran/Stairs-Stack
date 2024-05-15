using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Character character;
    public TextMeshProUGUI txtTime, txtStepCounter;
    public Slider colorSlider;
    public Image handler;
    public List<Material> chooseMaterials = null;
    int counter = 0, stepCounter;
    public List<Material> boxMaterial;
    public List<GameObject> box;
    public GameObject pnlGameOver;
    public AudioClip jump, levelSkip, levelFalse;
    public AudioSource aSource;
    void Start()
    {
        InvokeRepeating("SliderAndText", 0f, 1f);
    }
    public void Restart()
    {
        pnlGameOver.SetActive(false);
        SceneManager.LoadScene("GameScreen");
        Time.timeScale = 1f;
    }
    void SliderAndText()
    {
        int a = int.Parse(txtTime.text);

        if (a < 1) { a = 6; colorSlider.value = 1; }

        if (colorSlider.value == 1)
        {
            string s = handler.color.ToHexString();
            string s2 = character.GetTag();
            if (s2 != "")
            {
                if (s == s2)
                {
                    PlaySound(levelSkip);
                }
                else
                {
                    PlaySound(levelFalse);
                    pnlGameOver.SetActive(true);
                    Time.timeScale = 0;
                }
            }
            handler.color = boxMaterial[Random.Range(0, boxMaterial.Count)].color;
        }
        colorSlider.value -= 0.1666f;
        a--;
        txtTime.text = a.ToString();


    }
    public void PlaySound(AudioClip audio)
    {
        aSource.clip = audio;
        aSource.Play();
    }



    public void ColorBoxShifter(int click)
    {
        PlaySound(jump);
        stepCounter++;
        txtStepCounter.text = stepCounter.ToString();

        try
        {
            GameObject bx = box[0];
            Box firstBox = bx.GetComponent<Box>();
            Transform tf = box[box.Count - 1].GetComponent<Box>().transform;
            box.RemoveAt(0);
            firstBox.lastBox = tf.position;
            Vector3 objTransform = bx.transform.position;
            firstBox.box = objTransform;
            firstBox.anim = true;
            firstBox.material = ChooseMaterial();
            box.Add(bx);

        }
        catch (System.Exception)
        {
            SceneManager.LoadScene("GameScreen");
            throw;
        }
    }
    Material ChooseMaterial()
    {

        if (counter % 5 == 0)
        {
            counter = 0;
            chooseMaterials = boxMaterial;
            Shuffle(chooseMaterials);
        }
        Material a = chooseMaterials[counter];


        counter++;
        return a;
    }

    void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}