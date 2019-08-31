using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;
        private List<Card> captains;
        //Constructor
        public Game()
        {

        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }
        public bool ToBool(string str)
        {
            if (str == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CreateCaptains()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Captains.txt";
            StreamReader reader = new StreamReader(path);

            captains = new List<Card>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] characterParams = line.Split(',');


                switch (characterParams[0])
                {

                  
                    case "CombatCard":
                        //example CombatCard,Dethmold,range,null,6,false

                        captains.Add(new CombatCard(characterParams[1], (Enums.EnumType)Enum.Parse(typeof(Enums.EnumType),
                                                    characterParams[2]), characterParams[3],
                                                    Convert.ToInt32(characterParams[4]), ToBool(characterParams[5])));
                        break;
                    case "SpecialCard":
                        //example SpecialCard,Biting Frost,weather,Sets the strength of all melee cards to 1 for both players
                        captains.Add(new SpecialCard(characterParams[1], (Enums.EnumType)Enum.Parse(typeof(Enums.EnumType),
                                                     characterParams[2]), characterParams[3]));
                        break;

                    default:
                        break;
                }
                
            }
        }
        public void CreateDeck()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files\Decks.txt";
            StreamReader reader = new StreamReader(path);
            Deck deck = new Deck();
            decks = new List<Deck>();
            
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] characterParams = line.Split(',');
            
                    
                switch (characterParams[0])
                {
                        
                    case "START":
                        deck = new Deck();
                        break;
                    case "END":
                        decks.Add(deck);
                        break;
                    case "CombatCard":
                        //example CombatCard,Dethmold,range,null,6,false
                        
                        deck.AddCard(new CombatCard(characterParams[1], (Enums.EnumType)Enum.Parse(typeof(Enums.EnumType),
                                                    characterParams[2]), characterParams[3],
                                                    Convert.ToInt32( characterParams[4]), ToBool(characterParams[5])));
                        break;
                    case "SpecialCard":
                        //example SpecialCard,Biting Frost,weather,Sets the strength of all melee cards to 1 for both players
                        deck.AddCard(new SpecialCard(characterParams[1], (Enums.EnumType)Enum.Parse(typeof(Enums.EnumType), 
                                                     characterParams[2]), characterParams[3]));
                        break;

                    default:
                        break;
                }
                
            }
           

        }
    }
}
