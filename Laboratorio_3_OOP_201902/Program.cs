using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;

namespace Laboratorio_3_OOP_201902
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Deck deck = new Deck();
            //example CombatCard,Dethmold,range,null,6,false

            deck.AddCard(new CombatCard("Dethmold",Enums.EnumType.range, null, 6, false));
            
            
            //example SpecialCard,Biting Frost,weather,Sets the strength of all melee cards to 1 for both players
            deck.AddCard(new SpecialCard ("Biting Frost",Enums.EnumType.weather, "Sets the strength of all melee cards to 1 for both players"));


            Console.WriteLine(deck.Cards[1].Effect);
        }
    }
}
