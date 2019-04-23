using System;

namespace TrainingProject
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status Status { get; set; }
        public User Responsible { get; set; }
        public Type PlanType { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - NOME: {Name} - DATA INICIAL: {StartDate} - DATA FINAL: {EndDate} - STATUS: {Status.Name} - TIPO: {PlanType.Name}";
        }

    }


}
