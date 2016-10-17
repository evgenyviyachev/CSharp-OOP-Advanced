using _06MirrorImage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage.Models
{
    public class Wizard
    {
        public static int IDCount = 0;

        private string name;
        private int id;
        private int magicalPower;
        private Wizard leftWiz;
        private Wizard rightWiz;

        public Wizard(string name, int magicalPower)
        {
            this.Name = name;
            this.id = IDCount++;
            this.MagicalPower = magicalPower;
            this.LeftWiz = null;
            this.RightWiz = null;
        }
        
        public Wizard LeftWiz
        {
            get
            {
                return this.leftWiz;
            }
            set
            {
                this.leftWiz = value;
            }
        }

        public Wizard RightWiz
        {
            get
            {
                return this.rightWiz;
            }
            set
            {
                this.rightWiz = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public int MagicalPower
        {
            get
            {
                return this.magicalPower;
            }
            private set
            {
                this.magicalPower = value;
            }
        }

        public void CastMagic(IMagic magic)
        {
            magic.Cast(this);
        }
    }
}
