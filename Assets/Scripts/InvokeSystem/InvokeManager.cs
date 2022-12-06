using System.Collections.Generic;
using UnityEngine;

namespace InvokeSystem
{
    /// <summary>
    /// Control order of object invoking and setting up
    /// </summary>
    public class InvokeManager : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> monoBehaviours;

        private void Awake()
        {
            foreach (var mono in monoBehaviours)
            {
                if(mono == null) continue;

                IInvoke invoke = mono.GetComponent<IInvoke>();
                
                invoke.SetUp();
            }
        }

        #region Validation

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(monoBehaviours.Count == 0) return;
            
            for (int i = 0; i < monoBehaviours.Count; i++)
            {
                if (monoBehaviours[i] == null) continue;
                
                IInvoke invoke = monoBehaviours[i].GetComponent<IInvoke>();

                if (invoke == null)
                {
                    monoBehaviours.RemoveAt(i);
                }   
            }
        }
#endif

        #endregion
    }
}
