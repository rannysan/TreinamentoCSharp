

namespace TrainingProject
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - NOME: {Name}";
        }
    }
}
