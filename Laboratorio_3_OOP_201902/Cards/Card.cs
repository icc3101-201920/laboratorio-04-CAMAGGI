using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_3_OOP_201902.Cards
{
    public abstract class Card
    {
        //Atributos
        protected string name;
        protected Enums.EnumType type;
        protected string effect;

        //Constructor
        public Card()
        {

        }

        //Propiedades
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public Enums.EnumType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
        public string Effect
        {
            get
            {
                return this.effect;
            }
            set
            {
                this.effect = value;
            }
        }
        
    }
}
