using System;
using System.Collections.Generic;

namespace Uno3D.Core
{
    public class Player
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        private List<Card> _hand = new List<Card>();
        //Xự kiện thông báo khi bài trên tay thay đổi
        private event Action<Player> OnHandChanged;

        public Player(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddCard(Card card)
        {
            _hand.Add(card);
            OnHandChanged?.Invoke(this);
        }

        public bool PlayCard(Card card)
        {
            if (_hand.Contains(card))
            {
                _hand.Remove(card);
                OnHandChanged?.Invoke(this);
                return true;
            }
            return false;
        }
        public IReadOnlyList<Card> Hand => _hand.AsReadOnly();

        public int CardCount => _hand.Count;

        public bool IsOut() => _hand.Count == 0;
    }
}