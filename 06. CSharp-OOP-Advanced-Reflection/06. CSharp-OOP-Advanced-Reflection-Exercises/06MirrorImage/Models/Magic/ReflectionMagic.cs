using _06MirrorImage.Contracts;
using _06MirrorImage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage.Models.Magic
{
    public class ReflectionMagic : IMagic
    {
        public void Cast(Wizard wiz)
        {
            Console.WriteLine($"{wiz.Name} {wiz.ID} casts Reflection");

            if (wiz.LeftWiz == null && wiz.RightWiz == null)
            {
                Wizard leftWiz = new Wizard(wiz.Name, wiz.MagicalPower / 2);
                Wizard rightWiz = new Wizard(wiz.Name, wiz.MagicalPower / 2);
                wiz.LeftWiz = leftWiz;
                wiz.RightWiz = rightWiz;
                WizardRepository.AddWizard(leftWiz);
                WizardRepository.AddWizard(rightWiz);
            }
            else
            {
                wiz.LeftWiz.CastMagic(new ReflectionMagic());
                wiz.RightWiz.CastMagic(new ReflectionMagic());
            }
        }
    }
}
