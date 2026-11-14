using System;

public class Consulta {
    public Animal? Animal { get; set; }
    public Veterinario? Veterinario { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacoes { get; set; } = "";
    public string Situacao { get; set; } ="";// agendada, realizada ou cancelada
}
//List<Consulta>