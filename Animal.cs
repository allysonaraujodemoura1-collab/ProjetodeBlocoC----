public class Animal {
    public string Nome { get; set; } = "";
    public string Especie { get; set; } = "";
    public int Idade { get; set; }
    public string NomeTutor { get; set; } = "";
    public string TelefoneTutor { get; set; } = "";
    public bool Ativo { get; set; } = true;
    public int Id { get; private set; }
    public Animal(int id) {Id = id;}
}


