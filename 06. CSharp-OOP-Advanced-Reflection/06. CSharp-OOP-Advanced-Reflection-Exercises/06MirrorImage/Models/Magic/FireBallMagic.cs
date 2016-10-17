using _06MirrorImage.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage.Models.Magic
{
    public class FireBallMagic : IMagic
    {
        public void Cast(Wizard wiz)
        {
            Console.WriteLine($"{wiz.Name} {wiz.ID} casts Fireball for {wiz.MagicalPower} damage");

            if (wiz.LeftWiz != null && wiz.RightWiz != null)
            {
                wiz.LeftWiz.CastMagic(new FireBallMagic());
                wiz.RightWiz.CastMagic(new FireBallMagic());
            }
        }
    }
}
