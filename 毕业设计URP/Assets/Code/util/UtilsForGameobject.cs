using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Code.util
{
    public class UtilsForGameobject
    {
        public static List<Transform> getallChildren(Transform father)
        {
            List<Transform> result = new List<Transform>();
            //use bfs to get all children
            Queue<Transform> q = new Queue<Transform>();
            q.Enqueue(father);
            while (q.Count!=0)
            {
                Transform temp = q.Dequeue();
               
                result.Add(temp);
                Debug.Log(temp.name);
                
                for (int i = 0; i < temp.childCount; i++)
                {   
                    q.Enqueue(temp.GetChild(i));
                }
            }
            

            return result;
        }
        
        public static List<Transform> getallChildren_by_keyword(Transform father,string keyword)
        {
            List<Transform> result = new List<Transform>();
            //use bfs to get all children
            Queue<Transform> q = new Queue<Transform>();
            q.Enqueue(father);
            while (q.Count!=0)
            {
                Transform temp = q.Dequeue();
                if (Regex.Match(temp.name, @keyword).Success)
                {
                    result.Add(temp);
                    Debug.Log(temp.name);
                }
                for (int i = 0; i < temp.childCount; i++)
                {   
                    q.Enqueue(temp.GetChild(i));
                }
            }
            return result;
        }
    }
}