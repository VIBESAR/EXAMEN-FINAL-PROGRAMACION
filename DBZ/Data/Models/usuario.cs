using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBZ.Data.Models
{
    internal class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Humano {  get; set; }
        public string Poder {  get; set; }
        public string Nivel_Ki { get; set; }
        public string Universo { get; set; }

        public Usuario(int id, string nombre, int edad, bool humano, string poder, string nivelKi, string universo)
        {
            ID = id;
            Nombre = nombre;
            Edad = edad;
            Humano = humano;
            Poder = poder;
            Nivel_Ki = nivelKi;
            Universo = universo;
        }

        public Usuario() { }

    }
}
