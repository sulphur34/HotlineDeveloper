using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LevelSelectionSystem
{
    public class LevelSelectionElement : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _outline;

        public event Action<LevelSelectionElement> Pressed;

        [field: SerializeField] public uint Level { get; private set; }

        public void Select()
        {
            _outline.SetActive(true);
        }

        public void Deselect()
        {
            _outline.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Pressed?.Invoke(this);
        }
    }
}