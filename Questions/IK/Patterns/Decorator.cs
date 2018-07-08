using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Patterns
{
    abstract class Card
    {
        public abstract string Draw();
    }

    class PlayingCard : Card
    {
        public override string Draw()
        {
            return "";
        }
    }

    abstract class CardDecorator : Card
    {
        public Card card { get; set; }

        public CardDecorator(Card card)
        {
            this.card = card;
        }
    }

    class SuitCard : CardDecorator
    {
        public string suit { get; set; }
        public SuitCard(string suit, Card card): base(card)
        {
            this.suit = suit;
        }

        public override string Draw()
        {
            return $"{suit}_{this.card.Draw()}";
        }
    }

    class ColoredCard : CardDecorator
    {
        public string color { get; set; }
        public ColoredCard(string color, Card card) : base(card)
        {
            this.color = this.color;
        }

        public override string Draw()
        {
            return $"{this.color}_{this.card.Draw()}";
        }
    }

    class ValueCard : CardDecorator
    {
        public string value { get; set; }
        public ValueCard(string value, Card card) : base(card)
        {
            this.value = this.value;
        }

        public override string Draw()
        {
            return $"{value}_{this.card.Draw()}";
        }
    }

    class Decorator
    {
        static void main()
        {
            Card cardA = new ColoredCard("black",
                new SuitCard("spade",
                    new ValueCard("A", new PlayingCard())));

            Card cardB = new ColoredCard("red",
                new SuitCard("heart",
                    new ValueCard("Q", new PlayingCard())));

            Console.WriteLine(cardA.Draw());
            Console.WriteLine(cardB.Draw());
        }
    }
}
