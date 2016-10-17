using _06MirrorImage.Contracts;
using _06MirrorImage.Models;
using _06MirrorImage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage
{
    public class Startup
    {
        public static void Main()
        {
            string[] wizardZeroData = Console.ReadLine().Split();
            Wizard zero = new Wizard(wizardZeroData[0], int.Parse(wizardZeroData[1]));
            WizardRepository.AddWizard(zero);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] data = input.Split();
                int id = int.Parse(data[0]);
                string spellName = data[1];
                if (spellName == "REFLECTION")
                {
                    spellName = "ReflectionMagic";
                }
                else
                {
                    spellName = "FireBallMagic";
                }
                Type typeOfSpell = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .First(t => t.Name == spellName);
                var spell = (IMagic)Activator.CreateInstance(typeOfSpell);

                Wizard wiz = WizardRepository.ReturnWizardByID(id);
                wiz.CastMagic(spell);

                input = Console.ReadLine();
            }
        }
    }
}
