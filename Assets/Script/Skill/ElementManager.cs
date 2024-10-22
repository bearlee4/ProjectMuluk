using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    private SkillManager skillManager;
    private PyroESkill pyroESkill;


    public Boolean skill_Q = true;      //스킬사용가능
    public Boolean skill_E = true;

    public string skillText_1;
    public string skillText_2;

    // Pyro, Hydro, Anemo, Geo
    public List<String> Element = new List<String> { "Pyro", "Hydro", "Anemo", "Geo" };
    public List<float> QSkillDelay = new List<float> { 2, 3, 2, 3 };
    public List<float> ESkillDelay = new List<float> { 7, 8, 8, 7 };


    public int currentElement = 0;

    void Start() { skillManager = GetComponent<SkillManager>(); }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))      // Q스킬사용
        {
            UseQSkill();
        }

        if (Input.GetKeyDown(KeyCode.E))      // E스킬사용
        {
            UseESkill();
        }

        if (Input.GetKeyDown(KeyCode.Tab))    // 원소바꾸기
        {
            if (skill_Q && skill_E)       // 스킬 쿨타임 중 못 바꿈
                ChangeElement();
            else
                Debug.Log("스킬 쿨이 돌아가고 있어 바꾸지 못함");
        }

    }

    void ChangeElement()
    {
        currentElement = (currentElement + 1) % Element.Count;
        Debug.Log("현재 원소: " + Element[currentElement]);
    }

    private void UseQSkill()
    {
        float delay = QSkillDelay[currentElement];

        if (skill_Q)
        {
            Debug.Log("Q스킬 사용 중, currentElement: " + currentElement);
            skillManager.QSkill(currentElement);
            StartCoroutine(QSkillDelayCoroutine(delay));
        }
        else
        {
            Debug.Log("Q스킬 사용 불가, 쿨타임 중");
        }
    }
    private IEnumerator QSkillDelayCoroutine(float delay)
    {
        skill_Q = false;
        Debug.Log("Q스킬 쿨타임 중");
        yield return new WaitForSeconds(delay);
        Debug.Log("Q스킬 사용가능");
        skill_Q = true;
    }

    private void UseESkill()
    {
        float coolTime = ESkillDelay[currentElement];
        if (skill_E)
        {
            skillManager.ESkill(currentElement);
        }
        else
        {
            Debug.Log("E스킬 사용 불가, 쿨타임 중");
        }
    }
    internal IEnumerator SkillEDelayCoroutine(float delay)
    {
        Debug.Log("E스킬 쿨타임 중!!");
        yield return new WaitForSeconds(delay);
        Debug.Log("E스킬 사용가능");
        skill_E = true;
    }


}