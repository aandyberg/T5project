using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DesktopApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DAL dal = new DAL();
            dal.CreateTrainer("Kim", 31);
            List<Trainer> trainer = dal.ReadTrainer(31);
            foreach(Trainer t in trainer)
            {
                Console.WriteLine(t.tName);
            }
        }
    }
}
