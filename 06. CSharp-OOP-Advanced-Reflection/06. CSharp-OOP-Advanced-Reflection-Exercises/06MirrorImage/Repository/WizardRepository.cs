using _06MirrorImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage.Repository
{
    public static class WizardRepository
    {
        public static Dictionary<int, Wizard> Repository = new Dictionary<int, Wizard>();

        public static void AddWizard(Wizard wiz)
        {
            Repository.Add(wiz.ID, wiz);
        }

        public static Wizard ReturnWizardByID(int id)
        {
            Wizard wiz = Repository.Values.First(w => w.ID == id);
            return wiz;
        }
    }
}
