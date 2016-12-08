using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class ScriptsCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<Canvas> FloorNumbers = GameObject.FindObjectsOfType<Canvas>().Where(c => c.transform.name == "WorldCanvasFloor1").ToList();
        foreach (Canvas floor in FloorNumbers)
        {
            floor.GetComponentInChildren<Text>().text = GameObject.FindObjectOfType<DontDestroyScript>().Level1ElevatorLevel.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool? CompareFiles(string pLuaScriptTutorial, string pLuaScriptCompleted)
    {
        //pLuaScriptCompleted = "Test";
        //pLuaScriptTutorial = "Test";
        string tutorialSource = pLuaScriptTutorial;//File.ReadAllText(Environment.CurrentDirectory + "/Assets/Lua/Tutorial/" + pLuaScriptTutorial + "Tutorial" + ".lua");
        string completedSource;
        if (File.Exists(Environment.CurrentDirectory + "/Assets/Lua/Tutorial/" + pLuaScriptCompleted + "Completed" + ".lua"))
        {
            completedSource = File.ReadAllText(Environment.CurrentDirectory + "/Assets/Lua/Tutorial/" + pLuaScriptCompleted + "Completed" + ".lua");
        }
        else
        {
            return true;
        }
        tutorialSource = tutorialSource.Replace("then", "then\r\n");
        tutorialSource = tutorialSource.Replace("else", "else\r\n");
        tutorialSource = tutorialSource.Replace("end", "end\r\n");
        tutorialSource = tutorialSource.Replace("do", "do\r\n");

        completedSource = completedSource.Replace("then", "then\r\n");
        completedSource = completedSource.Replace("else", "else\r\n");
        completedSource = completedSource.Replace("end", "end\r\n");
        completedSource = completedSource.Replace("do", "do\r\n");
        //Debug.Log(tutorialSource);
        List<string> tutorialLines = tutorialSource.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        List<string> completedLines = completedSource.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();


        for (int i = 0; i < completedLines.Count; i++)
        {
            if (completedLines[i].StartsWith(" "))
            {
                completedLines[i] = completedLines[i].Trim();
                //Debug.Log(tutorialLines[i]);
            }
            if (completedLines[i] == String.Empty)
            {
                completedLines.Remove(completedLines[i]);
                i = 0;
            }
        }
        for (int i = 0; i < tutorialLines.Count; i++)
        {
            if (tutorialLines[i].StartsWith(" "))
            {
                tutorialLines[i] = tutorialLines[i].Trim();
                //Debug.Log(tutorialLines[i]);
            }
            if (tutorialLines[i] == String.Empty)
            {
                tutorialLines.Remove(tutorialLines[i]);
                i = 0;
            }
        }

        completedLines = completedLines.OrderBy(c=>c).ToList();
        tutorialLines = tutorialLines.OrderBy(c=>c).ToList();

        Debug.Log("Completed: " + completedLines.Count);
        Debug.Log("Tutorial: " + tutorialLines.Count);
        int r = 0;
        int s = 0;
        foreach (string line in completedLines)
        {
            Debug.Log(r + ":Completed :" + line);
            r++;
        }
        foreach (string line in tutorialLines)
        {
            Debug.Log(s + ":Tutorial :" + line);
            s++;
        }
        Debug.Log("Counted in Completed: " + r);
        Debug.Log("Counted in Tutorial: " + s);
        int q = 0;
        foreach (string line in completedLines)
        {
            if (line == tutorialLines[q])
            {
                q++;
                if (q == completedLines.Count)
                {
                    Debug.Log("Completed?");
                    return true;
                }
                continue;
            }
            else
            {
                bool wrongOnLine = true;
                if (pLuaScriptCompleted.Contains("Level1Elevator"))
                {
                    wrongOnLine = Level1(tutorialSource);
                }
                if (wrongOnLine)
                {
                    Debug.Log("Error on this line: " + tutorialLines[q]);
                    return false; 
                }
                else
                {
                    return null;
                }
            }
        }
        return false;
        #region old
        //var outcome = completedLines.Where(item => tutorialLines.Select(d => d).Contains(item));
        //var except = completedLines.Except(tutorialLines);
        //var except2 = tutorialLines.Except(completedLines);
        //bool CanContinue = false;
        //foreach (var i in outcome)
        //{
        //    if (i.Contains("") || i.Contains("--"))
        //    {
        //    }
        //    else
        //    {

        //        Debug.Log("Outcome Good: " + i);
        //        CanContinue = true;
        //        //Script is okay
        //    }
        //}
        //foreach (var i in except)
        //{
        //    if (i.Contains("--") || i.Contains(""))
        //    {
        //        Debug.Log("Questionable Lines: " + i);
        //    }
        //    else
        //    {
        //        CanContinue = false;
        //        Debug.Log("Except: Bad " + i);
        //    }
        //    //There are functions or text that are not supposed to be in there.
        //}
        //foreach (var i in except2)
        //{
        //    if (i.Contains("--") || i.Contains(""))
        //    {
        //        Debug.Log("Questionable Lines: " + i);
        //    }
        //    else
        //    {
        //        CanContinue = false;
        //        Debug.Log("Except: Bad " + i);
        //    }
        //    //There are functions or text that are not supposed to be in there.
        //}
        //if (CanContinue)
        //{
        //    Debug.Log("Execute the code");
        //}
        #endregion
    }
    public bool Level1(string pTutorialSource)
    {
        if (pTutorialSource.Contains("Elevator:TeleportUp") ||pTutorialSource.Contains("this:TeleportUp"))
        {
            GameObject.Find("DontDestroy").GetComponent<DontDestroyScript>().Level1ElevatorLevel = Int32.Parse(Regex.Match(pTutorialSource, @"\d+").Value);
            if (GameObject.Find("DontDestroy").GetComponent<DontDestroyScript>().Level1ElevatorLevel > 10)
            {
                return true;
            }
            DontDestroyOnLoad(GameObject.FindObjectOfType<DontDestroyScript>().gameObject);
            return false;
        }
        return true;
    }

    public void NextLevelCheck(string pSource)
    {
        if (pSource.Contains("Elevator:TeleportUp(10)") || pSource.Contains("this:TeleportUp(10)"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
