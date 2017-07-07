using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public class GerarNomes
    {
        Random rng = new Random();
        List<string> sobrenome = new List<string>() {
                "da Cunha", "Machado", "Pereira", "Silva", "da Silva", "de Souza", "da Cruz", "Seibert", "Schmidt", "de Camargo",
                "Tischler", "Froemming", "Hein", "Haup", "Schroder", "Schroer", "Gusmão", "dos Santos", "Mathias", "Hansel", "Zamberlan",
                "Correa", "Ferri", "Naegele", "Stein", "Schramel", "Froeder", "Knob", "Strieder", "Schneider"
        };

        List<String> nome = new List<string>() {
                "Roberto","Paulo","Maria","Joana","João","Ricardo","Mauricio","Leonardo","Mauro","Daniel","Daniela","Marcio","Marcia",
                "Mario", "Alfredo", "Zacarias", "André", "Alexandre", "Elenara", "Larissa", "Maisa", "Patricia", "Joana", "Maristela",
                "Paula", "Gislaine", "Charline", "Charlene", "Jessica", "Amanda", "Ana Paula", "Camila", "Carla", "Carlos", "Josildo",
                "Gustavo", "Mauricio", "Edivania", "Evania", "Mateus", "Matheus", "Douglas", "Rodrigo", "Marcelo", "Pablo", "Vilson", 
                "Vilmar", "Edmundo", "Ronaldo" 
        };

        public string GerarNome()
        {
            return nome[rng.Next(0, nome.Count)] + " " + sobrenome[rng.Next(0, sobrenome.Count)];
        }
    }
}
