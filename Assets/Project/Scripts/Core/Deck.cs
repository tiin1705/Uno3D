using NUnit.Framework;
using System.Collections.Generic;
using System;
namespace Uno3D.Core
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();
        private readonly Random _random = new Random();
        public Deck()
        {
            Initialize();
        }

        public void Initialize()
        {
            _cards.Clear();
            foreach(CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                if (color == CardColor.Wild) continue; //Xử lí bài đổi màu riêng
                //1. Mỗi màu có 1 lá số 0
                _cards.Add(new Card(color, CardValue.Zero));
                //2. Mỗi màu có 2 lá (từ 1-9 và các lá chức năng: Skip,Reverse,DrawTwo)
                for(int i = 0; i < 2; i++)
                {
                    //thêm lá số từ 1-9
                    for(CardValue v = CardValue.One; v <= CardValue.Nine; v++)
                    {
                        _cards.Add(new Card(color, v));
                    }
                }

                //Thêm lá chức năng có màu
                
                _cards.Add(new Card(color, CardValue.Skip));
                _cards.Add(new Card(color, CardValue.Reverse));
                _cards.Add(new Card(color, CardValue.DrawTwo));
            }
            //3. Thêm các lá bài đen, mỗi loại 4 lá
            for(int i = 0; i < 4; i++)
            {
                _cards.Add(new Card(CardColor.Wild, CardValue.Wild));
                _cards.Add(new Card(CardColor.Wild, CardValue.WildDrawFour));
            }
        }
        //Thuật toán xáo bài Fisher_Yate
        public void Shuffle()
        {
            int n = _cards.Count;
            if(n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        public Card Drawcard()
        {
            if( _cards.Count == 0)
            {
                //xáo lại sấp bài đã đánh
                return null;
            }

            Card drawnCard = _cards[0];
            _cards.RemoveAt(0);
            return drawnCard;   
        }
        public int Count => _cards.Count;
    }
}
