using System;
using System.Collections.Generic;

namespace TrainingProject
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<Plan> Plans { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - NOME: {Name} - DATA DE REGISTRO: {RegisterDate}";
        }

    }

}
