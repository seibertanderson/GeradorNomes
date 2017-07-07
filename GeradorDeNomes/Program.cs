using Database.Entidades;
using NewERP.Data.Local;
using NewERP.Data.Local.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VerificaDiretorioDados();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BancoDados bancoDados = new BancoDados();
            bancoDados.CriarOuAtualizar();
            bancoDados.Commit();
            //Application.Run(new Form1());            
            new RepositorioBase<CarroCor>(new BancoDados()).Incluir(new CarroCor("Branco"));
            new RepositorioBase<Carro>(new BancoDados()).Incluir(new Carro("Gol", 1));
        }


        static void VerificaDiretorioDados()
        {
            if (!Directory.Exists("..\\data"))
            {
                Directory.CreateDirectory("..\\data");
            }
        }
    }
}
